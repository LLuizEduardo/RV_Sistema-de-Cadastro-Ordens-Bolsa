using Microsoft.AspNetCore.Mvc;
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
            var listaAcoes = _bancoContent.Acoes;
            var listaOpcoes = _bancoContent.Opcoes;


            List<AcaoModel> acoes = listaAcoes.OrderByDescending(x => x.Data).ToList();
            List<OpcaoModel> opcoes = listaOpcoes.OrderByDescending(x => x.Data).ToList();
            Workspace ws = new Workspace { Acoes = acoes, Opcoes = opcoes };




            //OTHERS ADDITIONS
            double compraAcoes = listaAcoes.Where(x => x.Ordem == "Compra").Sum(x => x.Valor * x.Quantidade);
            double vendaAcoes = listaAcoes.Where(x => x.Ordem == "Venda").Sum(x => x.Valor * x.Quantidade);
            double totalAcoes = compraAcoes - vendaAcoes;

            var teste = from result in listaAcoes.ToList()
                        group result by result.Papel into novalista
                        select novalista;



            return View(ws);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
