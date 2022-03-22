namespace Exceptions
{
    /// <summary> Exceção de negócio lançada na tentativa de cadastro ou edição de um CPF de entidade ou objeto de valor.</summary>
    public class NumeroCPFInvalidoException : BusinessException
    {
        /// <summary>Construtor com parâmetros para inicialização.</summary>
        /// <param name="invalidCPF">Número de CPF inválido.</param>
        public NumeroCPFInvalidoException(string invalidCPF) :
            base("O número do CPF " + invalidCPF + "está incorreto.") {}
    }
}