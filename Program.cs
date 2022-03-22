using Exceptions;
using System;

namespace POC_CPF_SemTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    
        /// <summary>Valida se um determinado número de CPF é válido.</summary>
        /// <param name="numeroCPF">Número de CPF a ser validado.</param>
        public bool ValidarCPF(string numeroCPF)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            
            numeroCPF = numeroCPF.Replace(".", "").Replace("-", "");
            if (numeroCPF.Length != 11)
                throw new NumeroCPFInvalidoException(numeroCPF);

            tempCpf = numeroCPF.Substring(0, 9);
            soma = 0;

            
            for(int i=0; i<9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            
            resto = soma % 11;
            
            if ( resto < 2 )
                resto = 0;
            else
            resto = 11 - resto;
            
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            
            for(int i=0; i<10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            
            resto = soma % 11;
            
            if (resto < 2)
            resto = 0;
            else
            resto = 11 - resto;
            
            digito = digito + resto.ToString();

            if (!numeroCPF.EndsWith(digito))
                throw new NumeroCPFInvalidoException(numeroCPF);
        
            return true;
        }
    }
}
