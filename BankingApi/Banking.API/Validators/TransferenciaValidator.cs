using FluentValidation;
using static Banking.API.Models.DTO.Requests;

namespace Banking.API.Validators
{
    public class TransferenciaValidator :AbstractValidator<TransferenciaRequest>
    {
        public TransferenciaValidator() {

            RuleFor(x => x.ContaOrigem)
                .NotEmpty().WithMessage("O numero da conta de origerm é obrigatoria")
                .Matches(@"^\d{8}$").WithMessage("Conta origem deve conter 8 caratecteres");

            RuleFor(x => x.ContaDestino)
                .NotEmpty().WithMessage("O numero da conta de destino é obrigatoria")
                .Matches(@"^\d{8}$").WithMessage("Conta destino deve conter 8 caratecteres");

            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("O valor de tranferencia deve ser maior que zero");

            RuleFor(x => x.Descricao)
                .MaximumLength(200).WithMessage("A descrição der ter no maximo 200 caratecteres")
                .When(x => !string.IsNullOrEmpty(x.Descricao));
                
        }
    }
}
