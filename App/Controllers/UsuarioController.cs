using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RV.Domain.Models;
using RV.Infrastucture.Data;

namespace RV
{
    public class UsuarioController : Controller
    {
        private readonly BancoContent _bancoContent;

        public UsuarioController(BancoContent bancoContent)
        {
            _bancoContent = bancoContent;
        }

        public IActionResult Salvar()
        {
            return View();
        }
        public IActionResult Index()
        {
            List<UsuarioModel> user = _bancoContent.Usuarios.ToList();

            return View(user);
        }

        [HttpPost]
        public IActionResult Salvar(UsuarioModel user)
        {
            if (ModelState.IsValid)
            {
                user.DataCadastro = System.DateTime.Now;
                _bancoContent.Usuarios.Add(user);
                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                _bancoContent.SaveChanges();

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
            UsuarioModel userDB = _bancoContent.Usuarios.FirstOrDefault(x => x.Id == user.Id);
            return View(userDB);
        }

        [HttpPost]
        public IActionResult Atualizar(UsuarioModel user)
        {
            if (ModelState.IsValid)
            {
                user.DataAlteracao = System.DateTime.Now;
                _bancoContent.Usuarios.Update(user);
                TempData["MensagemSucesso"] = "Usuário editado com sucesso";
                _bancoContent.SaveChanges();

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
            UsuarioModel userDB = _bancoContent.Usuarios.FirstOrDefault(x => x.Id == user.Id);
            return View(userDB);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                UsuarioModel userDB = _bancoContent.Usuarios.FirstOrDefault(x => x.Id == id);
                _bancoContent.Usuarios.Remove(userDB);
                _bancoContent.SaveChanges();
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
