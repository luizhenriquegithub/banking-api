namespace Banking.API.Models.DTO
{
    public class Requests
    {
        public record CriarContaRequest(string NomeTitular, string CPF, TipoConta Tipo);

        public record DepositoRequest(string NumeroConta, decimal Valor)
        {
            //Construtor para permitir with expression
            public DepositoRequest(): this("",0) { }
        }

        public record SaqueRequest(string NumeroConta, decimal valor)
        {
            public SaqueRequest(): this("",0) { }
        }

        public record TransferenciaRequest(
           
            string ContaOrigem,
            string ContaDestino,
            decimal Valor,
            string? Descricao = null
            
         );
    }
}
