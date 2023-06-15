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

            List<TotalAcoes> acoesT = new();
            foreach (var v in liAcoes)
            {
                double C = listaAcoes.Where(x => x.Ordem == "Compra" && x.Papel == v.Key).Sum(x => x.Valor * x.Quantidade);
                double V = listaAcoes.Where(x => x.Ordem == "Venda" && x.Papel == v.Key).Sum(x => x.Valor * x.Quantidade);

                int Cq = listaAcoes.Where(x => x.Ordem == "Compra" && x.Papel == v.Key).Sum(x => x.Quantidade);
                int Vq = listaAcoes.Where(x => x.Ordem == "Venda" && x.Papel == v.Key).Sum(x => x.Quantidade);

                double T = C - V;
                int Tq = Cq - Vq;
                double Pm = T / Tq;

                acoesT.Add(new TotalAcoes { Papel = v.Key, Quantidade = Tq, Valor = T, PrecoMedio = Pm });
            }

            Workspace ws = new() { TotalAcoes = acoesT };

            return ws;
        }
    }
}
