using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RV.Models
{
    interface ILancamento
    {
        DateTime Data { get; set; }
        string Papel { get; set; }
        int Quantidade { get; set; }
        DateTime Vencimento { get; set; }
        double Valor { get; set; }
        string TipoOrdem { get; set; }
        string Corretora { get; set; }
    }
}
