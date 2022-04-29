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
        /// <summary>
        /// Restituisce tutti gli elementi scaduti
        /// </summary>
        /// <returns>Lista<ProdottoAlimentare> list contenente i prodotti scaduti, List<ProdottoAlimentare> [] altrimenti</returns>
        List<ProdottoAlimentare> GetPAExp();
        /// <summary>
        /// Restituisce tutti gli elementi quasi scaduti
        /// </summary>
        /// <returns>Lista<ProdottoAlimentare> list contenente i prodotti scaduti, List<ProdottoAlimentare> [] altrimenti</returns>
        List<ProdottoAlimentare> GetPAAlmostExp();
    }
}
