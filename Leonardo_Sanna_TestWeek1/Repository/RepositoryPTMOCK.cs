using Leonardo_Sanna_TestWeek1.Entities;
using Leonardo_Sanna_TestWeek1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna_TestWeek1.Repository
{
    internal class RepositoryPTMOCK : IRepositoryPT
    {
        static private List<ProdottoTecnologico> prodottiT = new List<ProdottoTecnologico>()
        {
            new ProdottoTecnologico("1223",1233,"pc","Dell",true),
            new ProdottoTecnologico("1344",234,"pc","HP",false)
        };

        public ProdottoTecnologico GetTByCode(string id)
        {
            foreach (ProdottoTecnologico itemT in prodottiT)
            {
                if (itemT.Codice == id)
                {
                    return itemT;
                }
            }
            return null;
        }

        public bool Aggiungi(ProdottoTecnologico item)
        {
            if(item == null || GetTByCode(item.Codice) != null)
            {
                Console.Clear();
                Console.WriteLine("Errore nell'inserimento del prodotto");
                return false;
            }

            prodottiT.Add(item);
            return true;
        }

        public List<ProdottoTecnologico> GetAll()
        {
            return prodottiT;
        }

        public List<ProdottoTecnologico> GetPTByMarca(string marca)
        {
            List<ProdottoTecnologico> filteredPT = new List<ProdottoTecnologico>();
            foreach(ProdottoTecnologico item in prodottiT)
            {
                if(item.Marca == marca)
                {
                    filteredPT.Add(item);
                }
            }
            return filteredPT;
        }

        public List<ProdottoTecnologico> GetPTNew()
        {
            List<ProdottoTecnologico> filteredPT = new List<ProdottoTecnologico>();
            foreach (ProdottoTecnologico item in prodottiT)
            {
                if (item.IsNew)
                {
                    filteredPT.Add(item);
                }
            }
            return filteredPT;
        }

        public bool IsVuota()
        {
            return (prodottiT.Count == 0);
        }
    }
}
