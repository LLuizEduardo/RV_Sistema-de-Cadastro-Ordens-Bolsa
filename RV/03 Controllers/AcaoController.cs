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

        public IActionResult Salvar(AcaoModel acao)
        {
            return View(acao);
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
