using System;
using System.ComponentModel.DataAnnotations;

namespace RV.Domain.Models
{
    public class AcaoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Escolha o papel")]
        public PapelModel Papel { get; set; }

        [Required(ErrorMessage = "Digite a quantidade")]
        [Range(1, 9999999)]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Digite o valor")]
        [Range(0.0001, 9999999)]
        public double Valor { get; set; }

        public char Ordem { get; set; }
        public CorretoraModel Corretora { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
