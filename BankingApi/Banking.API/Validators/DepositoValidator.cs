using Banking.API.Services;
using FluentValidation;
using static Banking.API.Models.DTO.Requests;

namespace Banking.API.Validators
{
    public class DepositoValidator : AbstractValidator<DepositoRequest>
    {
        private readonly IContaService _contaService;

        public DepositoValidator(IContaService contaService) { 

            _contaService = contaService;

            RuleFor(x => x.NumeroConta)
                .NotEmpty().WithMessage("O numero da conta é obrigatorio")
                .MustAsync(async (numeroConta, cancellation) => await _contaService.ContaExisteAsync(numeroConta))
                .WithMessage("Conta não encontrada");

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("O valor do deposito deve ser maior que zero");

        }
    }
}
