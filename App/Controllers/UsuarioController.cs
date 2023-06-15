using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RV.Domain.Models;
using RV.Infrastucture.Data;
using Domain.Interfaces;

namespace RV
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Salvar()
        {
            return View();
        }

        public IActionResult Index()
        {
            IEnumerable<UsuarioModel> users = _usuarioService.BuscarTodos();
            return View(users);
        }

        [HttpPost]
        public IActionResult Salvar(UsuarioModel user)
        {
            if (ModelState.IsValid)
            {
                user.DataCadastro = System.DateTime.Now;
                _usuarioService.Salvar(user);
                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Erro ao cadastrar. Avalie se todos os campos estão preenchidos.";
                return View(user);
            }
        }

        public IActionResult Editar(UsuarioModel user)
        {
            UsuarioModel userDB = _usuarioService.BuscarPorId(user.Id);
            return View(userDB);
        }

        [HttpPost]
        public IActionResult Atualizar(UsuarioModel user)
        {
            if (ModelState.IsValid)
            {
                user.DataAlteracao = System.DateTime.Now;
                _usuarioService.Editar(user);
                TempData["MensagemSucesso"] = "Usuário editado com sucesso";

                return Redirect("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Erro ao editar. Avalie se todos os campos estão corretos.";
                return View("Editar", user);
            }
        }

        public IActionResult ApagarConfirmacao(UsuarioModel user)
        {
            UsuarioModel userDB = _usuarioService.BuscarPorId(user.Id);
            return View(userDB);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                _usuarioService.Apagar(id);
                TempData["MensagemSucesso"] = "Usuário apagado com sucesso";
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Ocorreu um erro. Tente novamente.";
            }
            return RedirectToAction("Index");
        }
    }
}
