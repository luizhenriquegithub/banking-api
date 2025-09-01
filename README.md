
# Validações Inteligentes no .Net com Fluent Validations

O FluenteValidations é uma biblioteca popular para .NET, uma alternativa mais elegante e poderosa aos
Data Annotations tradicionais do .NET

## Configuração Inicial

```bash
1 - Instalação dos pacotes 
   
  - dotnet add package FluentValidation
  - dotnet add package FluentValidation.DepedencyInjection

2 - Configuração no Program.cs

  using FluentValidation;

  var builder = WebApplication.CreateBuilder(args);

  //Registrar FluentValidation
  builder.Services.AddValidatorsFromAssemblyContaining<Program>()

  var app = builder.Build();
```


