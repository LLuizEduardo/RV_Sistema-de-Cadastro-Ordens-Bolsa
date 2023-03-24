using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RV
{
    public class AcaoController : Controller
    {

        private readonly BancoContent _bancoContent;

        public AcaoController(BancoContent bancoContent)
        {
            _bancoContent = bancoContent;
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
            return View();
        }

        //public AcaoModel BuscaId(int id)
        //{
        //    return _bancoContent.Acoes.FirstOrDefault(x => x.Id == id);

        //}

        public IActionResult Editar(AcaoModel acao)
        {
            //AcaoModel acaoDB = BuscaId(acao.Id);
            //acaoDB.Data = acao.Data;
            //acaoDB.Papel = acao.Papel;
            //acaoDB.Quantidade = acao.Quantidade;
            //acaoDB.Valor = acao.Valor;
            //acaoDB.Corretora = acao.Corretora;
            //acaoDB.Ordem = acao.Ordem;

            return View();
        }

        
        private void ApaguePorModel(int id)
        {
           AcaoModel acaoDB = _bancoContent.Acoes.FirstOrDefault(x => x.Id == id);
            _bancoContent.Acoes.Remove(acaoDB);
            _bancoContent.SaveChanges();            
        }

        public IActionResult Apagar(int id)
        {
            ApaguePorModel(8);
            return RedirectToAction("IndexAcao");
        }
    }
}
