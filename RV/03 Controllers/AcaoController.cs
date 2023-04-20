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
        public IActionResult Index()
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
                TempData["MensagemSucesso"] = "Ordem cadastrada com sucesso";
                _bancoContent.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Erro ao cadastrar. Avalie se todos os campos estão preenchidos.";
                return View(acao);
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
                TempData["MensagemSucesso"] = "Ordem editada com sucesso";
                _bancoContent.SaveChanges();

                return Redirect("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Erro ao editar. Avalie se todos os campos estão corretos.";
                return View("Editar", acao);
            }
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                AcaoModel acaoDB = _bancoContent.Acoes.FirstOrDefault(x => x.Id == id);
                _bancoContent.Acoes.Remove(acaoDB);
                _bancoContent.SaveChanges();
                TempData["MensagemSucesso"] = "Ordem apagada com sucesso";
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Ocorreu um erro. Tente novamente.";
            }
            return RedirectToAction("Index");
        }
    }
}
