using Leonardo_Sanna_TestWeek1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna_TestWeek1.Interfaces
{
    internal interface IRepositoryPA : IRepository<ProdottoAlimentare>
    {
        List<ProdottoAlimentare> GetPAExp();
        List<ProdottoAlimentare> GetPAAlmostExp();
    }
}
