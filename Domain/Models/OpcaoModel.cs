using System;
using System.ComponentModel.DataAnnotations;

namespace RV.Domain.Models
{
    public class OpcaoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite a data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Digite a Opção")]
        public string Opcao { get; set; }
        public string Tipo { get; set; }
        public string Papel { get; set; }

        [Required(ErrorMessage = "Digite o Strike")]
        public double Strike { get; set; }

        [Required(ErrorMessage = "Digite a quantidade")]
        public int Quantidade { get; set; }
        public DateTime Vencimento { get; set; }

        [Required(ErrorMessage = "Digite o valor")]
        public double Valor { get; set; }
        public string Ordem { get; set; }
        public CorretoraModel Corretora { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
