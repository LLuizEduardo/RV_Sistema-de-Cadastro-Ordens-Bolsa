using Domain.Interfaces;
using RV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AcaoService : IAcaoService
    {
        public bool Apagar()
        {
            throw new NotImplementedException();
        }

        public Task<AcaoModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AcaoModel>> BuscarTodas()
        {
            throw new NotImplementedException();
        }

        public Task<AcaoModel> Criar(AcaoModel acao)
        {
            throw new NotImplementedException();
        }

        public Task<AcaoModel> Editar(AcaoModel acao)
        {
            throw new NotImplementedException();
        }
    }
}
