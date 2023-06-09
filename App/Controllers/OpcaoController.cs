using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RV.Domain.Models;
using Domain.Interfaces;

namespace RV
{
    public class OpcaoController : Controller
    {
        private readonly IOpcaoService _opcaoService;

        public OpcaoController(IOpcaoService opcaoService)
        {
            _opcaoService = opcaoService;
        }

        public IActionResult Nova()
        {
            return View();
        }

        public IActionResult Index()
        {
            IEnumerable<OpcaoModel> opcoes = _opcaoService.BuscarTodas();
            return View(opcoes);
        }

        [HttpPost]
        public IActionResult Salvar(OpcaoModel opcao)
        {
            if (ModelState.IsValid)
            {
                _opcaoService.Salvar(opcao);
                TempData["MensagemSucesso"] = "Ordem cadastrada com sucesso";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Erro ao cadastrar. Avalie se todos os campos estão preenchidos.";
                return View(opcao);
            }
        }

        public IActionResult Editar(OpcaoModel opcao)
        {
            OpcaoModel opcaoDB = _opcaoService.BuscarPorId(opcao.Id);
            return View(opcaoDB);
        }

        [HttpPost]
        public IActionResult Atualizar(OpcaoModel opcao)
        {
            if (ModelState.IsValid)
            {
                _opcaoService.Editar(opcao);
                TempData["MensagemSucesso"] = "Ordem editada com sucesso";

                return Redirect("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Erro ao editar. Avalie se todos os campos estão corretos.";
                return View("Editar", opcao);
            }
        }

        public IActionResult ApagarConfirmacao(OpcaoModel opcao)
        {
            OpcaoModel opcaoDB = _opcaoService.BuscarPorId(opcao.Id);
            return View(opcaoDB);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                _opcaoService.Apagar(id);
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
