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
        private readonly IAcaoService _acaoService;

        public AcaoController(BancoContent bancoContent, IAcaoService acaoService)
        {
            _acaoService = acaoService;
        }

        public IActionResult Nova()
        {
            return View();
        }

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
                _acaoService.Salvar(acao);
                TempData["MensagemSucesso"] = "Ordem cadastrada com sucesso";

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
            AcaoModel acaoDB = _acaoService.BuscarPorId(acao.Id);
            return View(acaoDB);
        }

        [HttpPost]
        public IActionResult Atualizar(AcaoModel acao)
        {
            if (ModelState.IsValid)
            {
                _acaoService.Editar(acao);
                TempData["MensagemSucesso"] = "Ordem editada com sucesso";

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
            AcaoModel acaoDB = _acaoService.BuscarPorId(acao.Id);
            return View(acaoDB);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                _acaoService.Apagar(id);
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
