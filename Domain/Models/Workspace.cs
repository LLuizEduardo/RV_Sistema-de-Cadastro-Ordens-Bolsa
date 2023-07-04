using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RV.Domain.Models
{
    public class Workspace
    {
        public List<PosicaoAcoes> PosicaoAcoes { get; set; }
    }

    public class PosicaoAcoes
    {
        public string Papel { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public double PrecoMedio { get; set; }
    }
}
