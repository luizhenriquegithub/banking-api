using Banking.API.Services;
using FluentValidation;
using static Banking.API.Models.DTO.Requests;

namespace Banking.API.Validators
{
    public class SaqueValidator :AbstractValidator<SaqueRequest>    
    {
        private readonly IContaService _contaService;

        public SaqueValidator(IContaService contaService)
        {
            _contaService = contaService;

            RuleFor(x => x.NumeroConta)
                .NotEmpty().WithMessage("O numero da conta é obrigatorio")
                .MustAsync(ContaExiste).WithMessage("Conta não encontrada ");

            RuleFor(x => x.valor)
                .GreaterThan(0).WithMessage("O valor do saque deve ser maior que zero");
        }

        private async Task<bool> ContaExiste(string numeroConta, CancellationToken cancellation)
        {
            return await _contaService.ContaExisteAsync(numeroConta);
        }

    }
}
