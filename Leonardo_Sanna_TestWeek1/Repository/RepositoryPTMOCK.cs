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
        
        public ProdottoTecnologico? GetTByCode(string id)
        {
            return prodottiT.FirstOrDefault(p => p.Codice == id);
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
            return prodottiT.Where(p => p.Marca==marca).ToList();
        }

        public List<ProdottoTecnologico> GetPTNew()
        {
            return prodottiT.Where(p => p.IsNew).ToList();
        }

        public bool IsVuota()
        {
            return (prodottiT.Count == 0);
        }

        public Task<List<ProdottoTecnologico>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
