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
        public Task<IEnumerable<OpcaoModel>> BuscarTodas();
        public Task<OpcaoModel> BuscarPorId(int id);
        public Task<OpcaoModel> Criar(OpcaoModel opcao);
        public Task<OpcaoModel> Editar(OpcaoModel opcao);
        public bool Apagar();
    }
}
