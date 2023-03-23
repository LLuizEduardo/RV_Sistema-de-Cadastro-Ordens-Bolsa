using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RV
{
    public class AcaoController : Controller
    {
        
        private readonly BancoContent _bancoContent;

        public AcaoController(BancoContent bancoContent)
        {
            _bancoContent = bancoContent;
        }


        public IActionResult IndexAcao()
        {
            List<AcaoModel> acoes = _bancoContent.Acoes.ToList();

            return View(acoes);
        }

        [HttpPost]
        public IActionResult Salvar(AcaoModel acao)
        {
            _bancoContent.Acoes.Add(acao);
            _bancoContent.SaveChanges();

            return RedirectToAction("IndexAcao");
        }


        //public IActionResult Editar(AcaoModel acao)
        //{
        //    return View();
        //}


        //public IActionResult Apagar(AcaoModel acao)
        //{
        //    return View();
        //}
    }
}
