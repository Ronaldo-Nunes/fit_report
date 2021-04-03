using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRelatorio.Auxiliar
{
    public class Validations
    {
        public static string MascaraCpf(string cpf)
        {
            string result = "";
            
            if (cpf.Length == 11)
            {
                result = cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            }
            if ((cpf.Length != 11))
            {
                result = cpf;
            }
            return result;
        }

        public static string RemoverMascaraCpf(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "");
        }

        public static int CalcularIdade(DateTime dataNascimento, DateTime dataReferencia)
        {
            int idade = dataReferencia.Year - dataNascimento.Year;

            //por anos bissextos precisamos disso
            if (dataNascimento > dataReferencia.AddYears(-idade)) idade--;

            return idade;
        }

    }
}
