using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RV.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RV
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly BancoContent _bancoContent;

        public HomeController(BancoContent bancoContent)
        {
            _bancoContent = bancoContent;
        }


        public IActionResult Index()
        {
            DbSet<AcaoModel> listaAcoes = _bancoContent.Acoes;
            DbSet<OpcaoModel> listaOpcoes = _bancoContent.Opcoes;


            List<AcaoModel> acoes = listaAcoes.OrderByDescending(x => x.Data).ToList();
            List<OpcaoModel> opcoes = listaOpcoes.OrderByDescending(x => x.Data).ToList();
            //Workspace ws = new() { Acoes = acoes, Opcoes = opcoes };
            List<TotalAcoes> acoesT = new();



            //OTHERS ADDITIONS
            double compraAcoes = listaAcoes.Where(x => x.Ordem == "Compra").Sum(x => x.Valor * x.Quantidade);
            double vendaAcoes = listaAcoes.Where(x => x.Ordem == "Venda").Sum(x => x.Valor * x.Quantidade);
            double totalAcoes = compraAcoes - vendaAcoes;

            var liAcoes = from result in listaAcoes.ToList()
                          group result by result.Papel into novalista
                          select novalista;


            foreach (var v in liAcoes)
            {
                double C = listaAcoes.Where(x => x.Ordem == "Compra" && x.Papel == v.Key).Sum(x => x.Valor * x.Quantidade);
                double V = listaAcoes.Where(x => x.Ordem == "Venda" && x.Papel == v.Key).Sum(x => x.Valor * x.Quantidade);

                int Cq = listaAcoes.Where(x => x.Ordem == "Compra" && x.Papel == v.Key).Sum(x => x.Quantidade);
                int Vq = listaAcoes.Where(x => x.Ordem == "Venda" && x.Papel == v.Key).Sum(x => x.Quantidade);
                //double V = listaAcoes.Where(x => x.Ordem == "Venda")
                //                     .Where(x => x.Papel == v.ToString())
                //                     .Sum(x => x.Valor * x.Quantidade);
                double T = C - V;
                int Tq = Cq - Vq;
                double Pm = T / Tq;

                acoesT.Add(new TotalAcoes { Papel = v.Key, Quantidade = Tq, Valor = T, PrecoMedio = Pm });
            }

            Workspace ws = new() { Acoes = acoes, Opcoes = opcoes, TotalAcoes = acoesT };
            return View(ws);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class TotalAcoes
    {
        public string Papel { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public double PrecoMedio { get; set; }
    }
}
