namespace Banking.API.Util
{
    public class ValidadorCPF
    {
        public static bool ValidarCPF(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (ex: 111.111.111-11)
            if (cpf.Distinct().Count() == 1)
                return false;

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int primeiroDigito = soma % 11;
            primeiroDigito = primeiroDigito < 2 ? 0 : 11 - primeiroDigito;

            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            int segundoDigito = soma % 11;
            segundoDigito = segundoDigito < 2 ? 0 : 11 - segundoDigito;

            // Verifica se os dígitos calculados são iguais aos informados
            return cpf[9] - '0' == primeiroDigito && cpf[10] - '0' == segundoDigito;
        }
    }
}
