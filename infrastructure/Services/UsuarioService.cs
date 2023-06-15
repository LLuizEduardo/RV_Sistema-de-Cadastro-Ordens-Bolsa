using Domain.Interfaces;
using RV.Domain.Models;
using RV.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly BancoContent _bancoContent;

        public UsuarioService(BancoContent bancoContent)
        {
            _bancoContent = bancoContent;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContent.Usuarios.OrderBy(x => x.Nome).ToList();
        }

        public UsuarioModel BuscarPorId(int id)
        {
            return _bancoContent.Usuarios.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(UsuarioModel user)
        {
            _bancoContent.Usuarios.Add(user);
            _bancoContent.SaveChanges();
        }

        public void Editar(UsuarioModel user)
        {
            _bancoContent.Usuarios.Update(user);
            _bancoContent.SaveChanges();
        }

        public void Apagar(int id)
        {
            UsuarioModel user = BuscarPorId(id);
            _bancoContent.Usuarios.Remove(user);
            _bancoContent.SaveChanges();
        }
    }
}
