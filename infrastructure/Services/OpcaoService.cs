using Domain.Interfaces;
using RV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OpcaoService : IOpcaoService
    {
        public bool Apagar()
        {
            throw new NotImplementedException();
        }

        public Task<OpcaoModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OpcaoModel>> BuscarTodas()
        {
            throw new NotImplementedException();
        }

        public Task<OpcaoModel> Criar(OpcaoModel opcao)
        {
            throw new NotImplementedException();
        }

        public Task<OpcaoModel> Editar(OpcaoModel opcao)
        {
            throw new NotImplementedException();
        }
    }
}
