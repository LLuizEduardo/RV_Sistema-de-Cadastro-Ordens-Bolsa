using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RV
{
    public class AcaoController : Controller
    {
        public IActionResult IndexAcao()
        {
            return View();
        }






        private readonly BancoContent _bancoContent;

        public AcaoController(BancoContent bancoContent)
        {
            _bancoContent = bancoContent;
        }


        [HttpPost]
        public IActionResult Salvar(AcaoModel acao)
        {
            _bancoContent.Acoes.Add(acao);
            _bancoContent.SaveChanges();

            return RedirectToAction("IndexAcao");
        }

        public IActionResult Editar(AcaoModel acao)
        {
            return View();
        }

        public IActionResult Listar(AcaoModel acao)
        {
            return View();
        }

        public IActionResult Apagar(AcaoModel acao)
        {
            return View();
        }
    }
}
