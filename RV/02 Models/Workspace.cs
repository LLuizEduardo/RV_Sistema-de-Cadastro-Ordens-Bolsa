using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RV
{
    public class Workspace
    {
        public List<AcaoModel> Acoes { get; set; }
        public List<OpcaoModel> Opcoes { get; set; }
        public List<TotalAcoes> TotalAcoes { get; set; }
    }
}
