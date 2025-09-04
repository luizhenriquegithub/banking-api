using Banking.API.Services;
using Banking.API.Util;
using FluentValidation;
using static Banking.API.Models.DTO.Requests;

namespace Banking.API.Validators
{
    public class CriarContaValidator : AbstractValidator<CriarContaRequest>
    {
        private readonly IContaService _contaService;   

        public CriarContaValidator(IContaService contaService)
        {
            _contaService = contaService;

            RuleFor(x => x.NomeTitular)
                .NotEmpty().WithMessage("O nome do titular é obrigatorio")
                .MaximumLength(100).WithMessage("O titular deve ter no maximo 100 carateres");

            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage("O CPF é obrigadorio")
                .Must(ValidadorCPF.ValidarCPF).WithMessage("CPF invalido");

            RuleFor(x => x.Tipo)
                .IsInEnum().WithMessage("O tipo de conta é invalido");

        }
    }
}