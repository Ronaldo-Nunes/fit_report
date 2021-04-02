using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitRelatorio.Model
{
    public class AvaliacaoAuxiliar
    {
        public long CodAluno { get; set; }
        public decimal GorduraInit { get; set; }
        public decimal MusculoInit { get; set; }
        public decimal CinturaInit { get; set; }
        public decimal QuadrilInit { get; set; }
        public decimal GorduraAtual { get; set; }
        public decimal MusculoAtual { get; set; }
        public decimal CinturaAtual { get; set; }
        public decimal QuadrilAtual { get; set; }

        public decimal RcqInit { get => Avaliacao.GetRcq(CinturaInit, QuadrilInit); }
        public decimal RcqAtual { get => Avaliacao.GetRcq(CinturaAtual, QuadrilAtual); }

    }
}
