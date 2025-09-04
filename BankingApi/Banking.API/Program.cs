using Banking.API.Services;
using FluentValidation;
using static Banking.API.Models.DTO.Requests;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

//Service
builder.Services.AddSingleton<IContaService, ContaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapPost("/contas", async (CriarContaRequest request,
    IValidator<CriarContaRequest> Validator,
    IContaService serive) =>
{
    var validationResult = await Validator.ValidateAsync(request);

    if(!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    var conta = await serive.CriarContaAsync(request);
    return Results.Created($"/contas/{conta.NumeroConta}", conta);

});

app.MapPost("/contas/{numeroConta}/deposito", async (string numeroConta, DepositoRequest request,
    IValidator<DepositoRequest> Validator,
    IContaService serive) =>
{
    request = request with { NumeroConta = numeroConta };

    var validationResult = await Validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    var conta = await serive.DepositarAsync(request);
    return Results.Ok(conta);

});

app.MapPost("/contas/{numeroConta}/saque", async (string numeroConta, SaqueRequest request,
    IValidator<SaqueRequest> Validator,
    IContaService serive) =>
{
    request = request with { NumeroConta = numeroConta };

    var validationResult = await Validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    var conta = await serive.SacarAsync(request);
    return Results.Ok(conta);

});

app.MapPost("transferencias", async (TransferenciaRequest request,
    IValidator<TransferenciaRequest> Validator,
    IContaService serive) =>
{
    var validationResult = await Validator.ValidateAsync(request);
    
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    await serive.TransferenciaAsync(request);
    return Results.Ok(new {Message = "Tranferencia realizada com sucesso"});

});

app.MapGet("/contas/{numeroConta}", async (string numeroConta, IContaService service) =>
{
    var conta = await service.GetContaAsync(numeroConta);

    return conta is not null ? Results.Ok(conta) : Results.NotFound();

});

app.Run();
