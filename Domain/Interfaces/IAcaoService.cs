using RV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAcaoService
    {
        public Task<IEnumerable<AcaoModel>> BuscarTodas();
        public Task<AcaoModel> BuscarPorId(int id);
        public Task<AcaoModel> Criar(AcaoModel acao);
        public Task<AcaoModel> Editar(AcaoModel acao);
        public bool Apagar();
    }
}
