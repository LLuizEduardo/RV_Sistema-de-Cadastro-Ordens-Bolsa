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

        public List<AcaoModel> BuscarTodas()
        {
            return _bancoContent.Acoes.OrderByDescending(x => x.Data).ToList();
        }

        public AcaoModel BuscarPorId(int id)
        {
            return _bancoContent.Acoes.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(AcaoModel acao)
        {
            if (acao.Ordem=="Venda")
                acao.Quantidade *= (-1);

            _bancoContent.Acoes.Add(acao);
            _bancoContent.SaveChanges();
        }

        public void Editar(AcaoModel acao)
        {
            _bancoContent.Acoes.Update(acao);
            _bancoContent.SaveChanges();
        }

        public void Apagar(int id)
        {
            AcaoModel acao = BuscarPorId(id);
            _bancoContent.Acoes.Remove(acao);
            _bancoContent.SaveChanges();
        }
    }
}
