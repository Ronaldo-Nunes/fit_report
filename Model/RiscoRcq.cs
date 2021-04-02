using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRelatorio.Model
{
    public class RiscoRcq
    {
        public long CodAluno { get; set; }
        public string Sexo { get; set; }
        public string FaixaEtaria { get; set; }
        public decimal RcqInit { get; set; }
        public decimal RcqAtual { get; set; }
        public string RiscoInicial { get; set; }
        public string RiscoAtual { get; set; }


        public static string GetRiscosRcq(string sexo, string faixaEtaria, decimal rcq)
        {
            string br = "Baixo";
            string mr = "Moderado";
            string ar = "Alto";
            string mar = "Muito alto";
            string risco;
            if (sexo.Equals("Masc"))
            {                
                if (faixaEtaria.Equals("-29"))
                {
                    if (rcq < 0.83m)
                    {
                        risco = br;
                    }
                    else if(rcq >= 0.83m && rcq < 0.88m)
                    {
                        risco = mr;
                    }
                    else if (rcq >= 0.88m && rcq < 0.94m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else if (faixaEtaria.Equals("30 - 39"))
                {
                    if (rcq < 0.84m)
                    {
                        risco = br;
                    }
                    else if (rcq >= 0.84m && rcq < 0.91m)
                    {
                        risco = mr;
                    }
                    else if (rcq >= 0.91m && rcq < 0.96m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else if (faixaEtaria.Equals("40 - 49"))
                {
                    if (rcq < 0.88m)
                    {
                        risco = br;
                    }
                    else if (rcq >= 0.88m && rcq < 0.95m)
                    {
                        risco = mr;
                    }
                    else if (rcq >= 0.95m && rcq < 1m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else if (faixaEtaria.Equals("50 - 59"))
                {
                    if (rcq < 0.90m)
                    {
                        risco = br;
                    }
                    else if (rcq >= 0.90m && rcq < 0.96m)
                    {
                        risco = mr;
                    }
                    else if (rcq >= 0.96m && rcq < 1.02m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else
                {
                    if (rcq < 0.91m)
                    {
                        risco = br;
                    }
                    else if (rcq >= 0.91m && rcq < 0.98m)
                    {
                        risco = mr;
                    }
                    else if (rcq >= 0.98m && rcq < 1.03m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
            }
            else
            {
                if (faixaEtaria.Equals("-29"))
                {
                    if (rcq < 0.71m)
                    {
                        risco = br;
                    }
                    else if (rcq >= 0.71m && rcq < 0.77m)
                    {
                        risco = mr;
                    }
                    else if (rcq >= 0.77m && rcq < 0.82m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else if (faixaEtaria.Equals("30 - 39"))
                {
                    if (rcq < 0.72m)
                    {
                        risco = br;
                    }
                    else if (rcq >= 0.72m && rcq < 0.78m)
                    {
                        risco = mr;
                    }
                    else if (rcq >= 0.78m && rcq < 0.84m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else if (faixaEtaria.Equals("40 - 49"))
                {
                    if (rcq < 0.73m)
                    {
                        risco = br;
                    }
                    else if (rcq >= 0.73m && rcq < 0.79m)
                    {
                        risco = mr;
                    }
                    else if (rcq >= 0.79m && rcq < 0.87m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else if (faixaEtaria.Equals("50 - 59"))
                {
                    if (rcq < 0.74m)
                    {
                        risco = br;
                    }
                    else if (rcq >= 0.74m && rcq < 0.81m)
                    {
                        risco = mr;
                    }
                    else if (rcq >= 0.81m && rcq < 0.88m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else
                {
                    if (rcq < 0.76m)
                    {
                        risco = br;
                    }
                    else if (rcq >= 0.76m && rcq < 0.83m)
                    {
                        risco = mr;
                    }
                    else if (rcq >= 0.83m && rcq < 0.90m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
            }

            return risco;
        }
    }
}
