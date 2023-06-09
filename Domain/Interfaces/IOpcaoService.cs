using RV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOpcaoService
    {
        public List<OpcaoModel> BuscarTodas();
        public OpcaoModel BuscarPorId(int id);
        public void Salvar(OpcaoModel opcao);
        public void Editar(OpcaoModel opcao);
        public void Apagar(int id);
    }
}
