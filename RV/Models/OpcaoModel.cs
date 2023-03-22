using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RV.Models
{
    public class OpcaoModel : ILancamento
    {
        public DateTime Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Papel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Quantidade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Vencimento { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Valor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TipoOrdem { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Corretora { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
