using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RV
{
    public class OpcaoController : Controller
    {
        public IActionResult IndexOpcao()
        {
            return View();
        }
        public IActionResult Salvar(OpcaoModel opcao)
        {
            return View(opcao);
        }

        public IActionResult Editar(OpcaoModel opcao)
        {
            return View();
        }

        public IActionResult Listar(OpcaoModel opcao)
        {
            return View();
        }

        public IActionResult Apagar(OpcaoModel opcao)
        {
            return View();
        }
    }
}
