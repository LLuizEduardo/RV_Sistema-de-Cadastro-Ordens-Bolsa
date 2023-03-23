using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RV
{
    public class OpcaoModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Opcao { get; set; }
        public string Tipo { get; set; }
        public string Papel { get; set; }
        public double Strike { get; set; }
        public int Quantidade { get; set; }
        public DateTime Vencimento { get; set; }
        public double Valor { get; set; }
        public string Ordem { get; set; }
        public string Corretora { get; set; }
    }
}
