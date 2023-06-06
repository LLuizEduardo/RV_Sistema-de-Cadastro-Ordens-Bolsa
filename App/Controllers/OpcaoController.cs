using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RV.Domain.Models;
using RV.Infrastucture.Data;

namespace RV
{
    public class OpcaoController : Controller
    {
        private readonly BancoContent _bancoContent;

        public OpcaoController(BancoContent bancoContent)
        {
            _bancoContent = bancoContent;
        }

        public IActionResult Salvar()
        {
            return View();
        }
        public IActionResult Index()
        {
            List<OpcaoModel> opcoes = _bancoContent.Opcoes.OrderByDescending(x => x.Data).ToList();

            return View(opcoes);
        }

        [HttpPost]
        public IActionResult Salvar(OpcaoModel opcaoe)
        {
            if (ModelState.IsValid)
            {
                opcaoe.Opcao = opcaoe.Opcao.Trim().ToUpper();
                _bancoContent.Opcoes.Add(opcaoe);
                TempData["MensagemSucesso"] = "Ordem cadastrada com sucesso";
                _bancoContent.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Erro ao cadastrar. Avalie se todos os campos estão preenchidos.";
                return View(opcaoe);
            }
        }

        public IActionResult Editar(OpcaoModel opcaoe)
        {
            OpcaoModel opcaoDB = _bancoContent.Opcoes.FirstOrDefault(x => x.Id == opcaoe.Id);
            return View(opcaoDB);
        }

        [HttpPost]
        public IActionResult Atualizar(OpcaoModel opcaoe)
        {
            if (ModelState.IsValid)
            {
                _bancoContent.Opcoes.Update(opcaoe);
                TempData["MensagemSucesso"] = "Ordem editada com sucesso";
                _bancoContent.SaveChanges();

                return Redirect("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Erro ao editar. Avalie se todos os campos estão corretos.";
                return View("Editar", opcaoe);
            }
        }

        public IActionResult ApagarConfirmacao(OpcaoModel opcaoe)
        {
            OpcaoModel opcaoDB = _bancoContent.Opcoes.FirstOrDefault(x => x.Id == opcaoe.Id);
            return View(opcaoDB);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                OpcaoModel opcaoDB = _bancoContent.Opcoes.FirstOrDefault(x => x.Id == id);
                _bancoContent.Opcoes.Remove(opcaoDB);
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