using Banking.API.Models;
using static Banking.API.Models.DTO.Requests;

namespace Banking.API.Services
{
    public interface IContaService
    {
        Task<Conta> CriarContaAsync(CriarContaRequest request);

        Task<Conta> DepositarAsync(DepositoRequest request);

        Task<Conta> SacarAsync(SaqueRequest request);
        
        Task TransferenciaAsync(TransferenciaRequest request);

        Task<Conta?> GetContaAsync(string numeroConta);

        Task<bool> ContaExisteAsync(string numeroConta);

        Task<decimal> GetSaldoAsync(string numeroConta);

        Task<bool> CPFJacadastrado(string cpf);

        Task<decimal> GetTranferenciasDiariasAsync(string numeroConta);
    }
}
