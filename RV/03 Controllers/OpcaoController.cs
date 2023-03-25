using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RV
{
    public class OpcaoController : Controller
    {
        private readonly BancoContent _bancoContent;
        public OpcaoController(BancoContent bancoContent)
        {
            _bancoContent = bancoContent;
        }
        public IActionResult IndexOpcao()
        {
            List<OpcaoModel> opcoes = _bancoContent.Opcoes.ToList();

            return View(opcoes);
        }

        [HttpPost]
        public IActionResult Salvar(OpcaoModel opcaoe)
        {
            if (ModelState.IsValid)
            {
                _bancoContent.Opcoes.Add(opcaoe);
                _bancoContent.SaveChanges();

                return RedirectToAction("IndexOpcao");
            }

            return View();
        }

        public IActionResult Editar(OpcaoModel opcaoe)
        {
            OpcaoModel opcaoDB = _bancoContent.Opcoes.FirstOrDefault(x=>x.Id==opcaoe.Id);

            return View(opcaoDB);
        }

        [HttpPost]
        public IActionResult Atualizar(OpcaoModel opcaoe)
        {
            _bancoContent.Opcoes.Update(opcaoe);
            _bancoContent.SaveChanges();
            return RedirectToAction("IndexOpcao");
        }


        public IActionResult Apagar(int id)
        {
            OpcaoModel opcao = _bancoContent.Opcoes.FirstOrDefault(x=>x.Id==id);
            _bancoContent.Opcoes.Remove(opcao);
            _bancoContent.SaveChanges();


            return RedirectToAction("IndexOpcao");
        }
    }
}