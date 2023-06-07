using Domain.Interfaces;
using RV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UsuarioService : IUsuarioService
    {
        public bool Apagar()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioModel>> BuscarTodas()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioModel> Criar(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioModel> Editar(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }
    }
}
