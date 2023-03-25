using System;
using System.ComponentModel.DataAnnotations;

namespace RV
{
    public class AcaoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Escolha o papel")]
        public string Papel { get; set; }
        
        [Required(ErrorMessage = "Digite a quantidade")]
        public int Quantidade { get; set; }
        
        [Required(ErrorMessage = "Digite o valor")]
        public double Valor { get; set; }
        
        public string Ordem { get; set; }
        public string Corretora { get; set; }
    }
}
