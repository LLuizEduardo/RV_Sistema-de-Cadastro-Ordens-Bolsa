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
        public List<AcaoModel> BuscarTodas();
        public AcaoModel BuscarPorId(int id);
        public void Salvar(AcaoModel acao);
        public void Editar(AcaoModel acao);
        public void Apagar(int id);
    }
}
