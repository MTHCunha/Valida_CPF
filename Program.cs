using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaCPF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.Write("Digite um CPF a ser validado: ");
                string cpf = Console.ReadLine(); //CPF a ser validado

                if (ValidaCPF(cpf))
                    Console.WriteLine("CPF válido.");
                else
                    Console.WriteLine("CPF inválido.");

                Console.ReadKey();
            }


             bool ValidaCPF(string cpf)
            {
                int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                cpf = cpf.Trim().Replace(".", "").Replace("-", "");

                if (cpf.Length != 11)
                    return false;

                string tempCpf = cpf.Substring(0, 9);

                int soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

                int resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                string digito = resto.ToString();
                tempCpf += digito;

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito += resto.ToString();

                return cpf.EndsWith(digito);
            }
 
        }
    }
}
