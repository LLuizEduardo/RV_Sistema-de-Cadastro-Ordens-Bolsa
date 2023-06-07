using Domain.Interfaces;
using RV.Domain.Models;
using RV.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AcaoService : IAcaoService
    {
        private readonly BancoContent _bancoContent;

        public AcaoService(BancoContent bancoContent)
        {
            _bancoContent = bancoContent;
        }

        public bool Apagar()
        {
            throw new NotImplementedException();
        }

        public Task<AcaoModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<AcaoModel> BuscarTodas()
        {
            return _bancoContent.Acoes.OrderByDescending(x => x.Data).ToList();
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
