using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RV
{
    public class AcaoController : Controller
    {
        private readonly BancoContent _bancoContent;

        public AcaoController(BancoContent bancoContent)
        {
            _bancoContent = bancoContent;
        }

        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult IndexAcao()
        {
            List<AcaoModel> acoes = _bancoContent.Acoes.ToList();

            return View(acoes);
        }

        [HttpPost]
        public IActionResult Salvar(AcaoModel acao)
        {
            if (ModelState.IsValid)
            {
                _bancoContent.Acoes.Add(acao);
                _bancoContent.SaveChanges();

                return RedirectToAction("IndexAcao");
            }
            return RedirectToAction("Cadastro");
        }
        
        public IActionResult Editar(AcaoModel acao)
        {
            AcaoModel acaoDB = _bancoContent.Acoes.FirstOrDefault(x => x.Id == acao.Id);
            return View(acaoDB);
        }

        [HttpPost]
        public IActionResult Atualizar(AcaoModel acao)
        {
            _bancoContent.Acoes.Update(acao);
            _bancoContent.SaveChanges();

            return Redirect("IndexAcao");
        }

        public IActionResult Apagar(int id)
        {
            AcaoModel acaoDB = _bancoContent.Acoes.FirstOrDefault(x => x.Id == id);
            _bancoContent.Acoes.Remove(acaoDB);
            _bancoContent.SaveChanges();

            return RedirectToAction("IndexAcao");
        }
    }
}
