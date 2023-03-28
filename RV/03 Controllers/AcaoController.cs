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

        public IActionResult Salvar()
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
            try
            {
                if (ModelState.IsValid)
                {
                    _bancoContent.Acoes.Add(acao);
                    TempData["MensagemSucesso"] = "Ordem cadastrada com sucesso";
                    _bancoContent.SaveChanges();

                    return RedirectToAction("IndexAcao");
                }
                return View(acao);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar: {erro.Message}";
                return RedirectToAction("IndexAcao");
            }
        }
        
        public IActionResult Editar(AcaoModel acao)
        {
            AcaoModel acaoDB = _bancoContent.Acoes.FirstOrDefault(x => x.Id == acao.Id);
            return View(acaoDB);
        }

        [HttpPost]
        public IActionResult Atualizar(AcaoModel acao)
        {
            if (ModelState.IsValid)
            {
            _bancoContent.Acoes.Update(acao);
            _bancoContent.SaveChanges();

            return Redirect("IndexAcao");
            }
            return View("Editar", acao);
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
