﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RV
{
    public class AcaoModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Papel { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public string TipoOrdem { get; set; }
        public string Corretora { get; set; }
    }
}
