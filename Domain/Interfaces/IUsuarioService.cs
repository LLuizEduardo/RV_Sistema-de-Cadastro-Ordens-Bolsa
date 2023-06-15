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
        public List<UsuarioModel> BuscarTodos();
        public UsuarioModel BuscarPorId(int id);
        public void Salvar(UsuarioModel usuario);
        public void Editar(UsuarioModel usuario);
        public void Apagar(int id);
    }
}
