using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRelatorio.Model
{
    public enum InfoGrafico
    {
        TaxaGordura,
        MassaMuscular,
        Peso,
        RelacaoQuadrilCintura,
        Metabolismo
    }

    public class ObjetoAuxiliar
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

    }   
}
