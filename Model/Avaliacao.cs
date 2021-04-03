﻿using System;
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

        public static decimal GetVariacaoCampo(decimal valorAnt, decimal valorAtual)
        {
            decimal res = Math.Round(((valorAtual * 100) / valorAnt) - 100, 2);
            return res;
        }

        public static decimal GetRcq(decimal cintura, decimal quadril)
        {
            return Math.Round(cintura / quadril, 2);
        }

        public decimal GetImc()
        {
            return Math.Round(Peso / (Altura * Altura), 2);
        }

        public decimal GetRcq()
        {
            return Math.Round(Cintura / Quadril, 2);
        }

        public string GetGrauRiscoRcq(string sexo)
        {
            string br = "Baixo";
            string mr = "Moderado";
            string ar = "Alto";
            string mar = "Muito alto";
            string risco;
            if (sexo.Equals("M"))
            {
                if (Idade <= 29)
                {
                    if (Rcq < 0.83m)
                    {
                        risco = br;
                    }
                    else if (Rcq >= 0.83m && Rcq < 0.88m)
                    {
                        risco = mr;
                    }
                    else if (Rcq >= 0.88m && Rcq < 0.94m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else if (Idade >= 30 && Idade <= 39)
                {
                    if (Rcq < 0.84m)
                    {
                        risco = br;
                    }
                    else if (Rcq >= 0.84m && Rcq < 0.91m)
                    {
                        risco = mr;
                    }
                    else if (Rcq >= 0.91m && Rcq < 0.96m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else if (Idade >= 40 && Idade <= 49)
                {
                    if (Rcq < 0.88m)
                    {
                        risco = br;
                    }
                    else if (Rcq >= 0.88m && Rcq < 0.95m)
                    {
                        risco = mr;
                    }
                    else if (Rcq >= 0.95m && Rcq < 1m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else if (Idade >= 50 && Idade <= 59)
                {
                    if (Rcq < 0.90m)
                    {
                        risco = br;
                    }
                    else if (Rcq >= 0.90m && Rcq < 0.96m)
                    {
                        risco = mr;
                    }
                    else if (Rcq >= 0.96m && Rcq < 1.02m)
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
                    if (Rcq < 0.91m)
                    {
                        risco = br;
                    }
                    else if (Rcq >= 0.91m && Rcq < 0.98m)
                    {
                        risco = mr;
                    }
                    else if (Rcq >= 0.98m && Rcq < 1.03m)
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
                if (Idade <= 29)
                {
                    if (Rcq < 0.71m)
                    {
                        risco = br;
                    }
                    else if (Rcq >= 0.71m && Rcq < 0.77m)
                    {
                        risco = mr;
                    }
                    else if (Rcq >= 0.77m && Rcq < 0.82m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else if (Idade >= 30 && Idade <= 39)
                {
                    if (Rcq < 0.72m)
                    {
                        risco = br;
                    }
                    else if (Rcq >= 0.72m && Rcq < 0.78m)
                    {
                        risco = mr;
                    }
                    else if (Rcq >= 0.78m && Rcq < 0.84m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else if (Idade >= 40 && Idade <= 49)
                {
                    if (Rcq < 0.73m)
                    {
                        risco = br;
                    }
                    else if (Rcq >= 0.73m && Rcq < 0.79m)
                    {
                        risco = mr;
                    }
                    else if (Rcq >= 0.79m && Rcq < 0.87m)
                    {
                        risco = ar;
                    }
                    else
                    {
                        risco = mar;
                    }
                }
                else if (Idade >= 50 && Idade <= 59)
                {
                    if (Rcq < 0.74m)
                    {
                        risco = br;
                    }
                    else if (Rcq >= 0.74m && Rcq < 0.81m)
                    {
                        risco = mr;
                    }
                    else if (Rcq >= 0.81m && Rcq < 0.88m)
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
                    if (Rcq < 0.76m)
                    {
                        risco = br;
                    }
                    else if (Rcq >= 0.76m && Rcq < 0.83m)
                    {
                        risco = mr;
                    }
                    else if (Rcq >= 0.83m && Rcq < 0.90m)
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
