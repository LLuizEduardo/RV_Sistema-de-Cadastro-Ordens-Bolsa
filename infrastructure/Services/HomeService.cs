using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using RV.Domain.Models;
using RV.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class HomeService : IHomeService
    {
        private readonly BancoContent _bancoContent;

        public HomeService(BancoContent bancoContent)
        {
            _bancoContent = bancoContent;
        }
        public Workspace GetWorkspace()
        {
            DbSet<AcaoModel> listaAcoes = _bancoContent.Acoes;
            DbSet<OpcaoModel> listaOpcoes = _bancoContent.Opcoes;

            var liAcoes = from result in listaAcoes.ToList()
                          group result by result.Papel into novalista
                          select novalista;

            List<PosicaoAcoes> posicaoAcoes = new();
            foreach (var v in liAcoes)
            {
                double valor = listaAcoes.Where(x => x.Papel == v.Key).Sum(x => x.Valor * x.Quantidade);

                int quantidade = listaAcoes.Where(x => x.Papel == v.Key).Sum(x => x.Quantidade);

                posicaoAcoes.Add(new PosicaoAcoes { Papel = v.Key, Quantidade = quantidade, Valor = valor, PrecoMedio = valor/quantidade });
            }

            return new Workspace() { PosicaoAcoes = posicaoAcoes };
        }
    }
}
