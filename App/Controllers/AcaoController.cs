using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RV.Domain.Models;
using RV.Infrastucture.Data;
using Domain.Interfaces;

namespace RV
{
    public class AcaoController : Controller
    {
        private readonly BancoContent _bancoContent;
        private readonly IAcaoService _acaoService;

        public AcaoController(BancoContent bancoContent, IAcaoService acaoService)
        {
            _bancoContent = bancoContent;
            _acaoService = acaoService;
        }

        //public IActionResult Salvar()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            IEnumerable<AcaoModel> acoes = _acaoService.BuscarTodas();
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

        public IActionResult ApagarConfirmacao(AcaoModel acao)
        {
            AcaoModel acaoDB = _bancoContent.Acoes.FirstOrDefault(x => x.Id == acao.Id);
            return View(acaoDB);
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
