using System;
using System.ComponentModel.DataAnnotations;

namespace RV
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Login { get; set; }

        [Required]
        public string Email { get; set; }
        public EnumPerfil Perfil { get; set; }
        [Required]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

    }
}
