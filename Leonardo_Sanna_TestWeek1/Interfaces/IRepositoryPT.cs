using Leonardo_Sanna_TestWeek1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna_TestWeek1.Interfaces
{
    internal interface IRepositoryPT : IRepository<ProdottoTecnologico>
    {
        List<ProdottoTecnologico> GetPTByMarca(string marca);

        List<ProdottoTecnologico> GetPTNew();
    }
}
