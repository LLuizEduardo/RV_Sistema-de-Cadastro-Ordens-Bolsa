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
    public class OpcaoService : IOpcaoService
    {
        private readonly BancoContent _bancoContent;

        public OpcaoService(BancoContent bancoContent)
        {
            _bancoContent = bancoContent;
        }

        public List<OpcaoModel> BuscarTodas()
        {
            return _bancoContent.Opcoes.OrderByDescending(x => x.Data).ToList();
        }

        public OpcaoModel BuscarPorId(int id)
        {
            return _bancoContent.Opcoes.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(OpcaoModel opcao)
        {
            if (opcao.Ordem == 'V')
                opcao.Quantidade *= (-1);

            _bancoContent.Opcoes.Add(opcao);
            _bancoContent.SaveChanges();
        }

        public void Editar(OpcaoModel opcao)
        {
            _bancoContent.Opcoes.Update(opcao);
            _bancoContent.SaveChanges();
        }

        public void Apagar(int id)
        {
            OpcaoModel opcao = BuscarPorId(id);
            _bancoContent.Opcoes.Remove(opcao);
            _bancoContent.SaveChanges();
        }
    }
}
