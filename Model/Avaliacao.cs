using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRelatorio.Model
{
    public class Avaliacao
    {
        public long CodAvaliacao { get; set; }
        public long CodAluno { get; set; }
        public DateTime Data { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public decimal Imc { get; set; }
        public decimal GorduraCorporal { get; set; }
        public decimal MassaMuscEsqueletica { get; set; }
        public int MetabolismoBasal { get; set; }
        public int IdadeCorporal { get; set; }
        public int GorduraVisceral { get; set; }
        public decimal Cintura { get; set; }
        public decimal Quadril { get; set; }
        public decimal Rcq { get; set; }
        public string GrauRisco { get; set; }
        public int Idade { get; set; }


        public decimal GetImc()
        {
            return Math.Round(Peso / (Altura * Altura), 2);
        }

        public static decimal GetVariacaoCampo(decimal valorAnt, decimal valorAtual)
        {
            decimal res = Math.Round(((valorAtual * 100) /valorAnt) - 100, 2);
            return res;            
        }

        public static decimal GetRcq(decimal cintura, decimal quadril)
        {
            return Math.Round(cintura / quadril, 2);
        }

        public string GetClassifcImc()
        {
            if (Imc < 17)
            {
                return "Muito abaixo do peso";
            }
            else if (Imc < 18.49m)
            {
                return "Abaixo do peso";
            }
            else if (Imc < 24.99m)
            {
                return "Peso normal";
            }
            else if (Imc < 29.99m)
            {
                return "Acima do peso";
            }
            else if (Imc < 34.99m)
            {
                return "Obesidade I";
            }
            else if (Imc < 39.99m)
            {
                return "Obesidade II (severa)";
            }
            else
            {
                return "Obesidade III (mórbida)";
            }
        }

    }
}
