using RV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuarioService
    {
        public Task<IEnumerable<UsuarioModel>> BuscarTodas();
        public Task<UsuarioModel> BuscarPorId(int id);
        public Task<UsuarioModel> Criar(UsuarioModel usuario);
        public Task<UsuarioModel> Editar(UsuarioModel usuario);
        public bool Apagar();
    }
}
