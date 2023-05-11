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
            List<AcaoModel> acoes = _bancoContent.Acoes.OrderByDescending(x => x.Data).ToList();
            List<OpcaoModel> opcoes = _bancoContent.Opcoes.OrderByDescending(x => x.Data).ToList();
            Workspace ws = new Workspace { Acoes = acoes, Opcoes = opcoes };

            return View(ws);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
