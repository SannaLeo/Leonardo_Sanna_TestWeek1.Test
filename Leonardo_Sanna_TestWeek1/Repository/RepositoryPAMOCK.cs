using Leonardo_Sanna_TestWeek1.Entities;
using Leonardo_Sanna_TestWeek1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna_TestWeek1.Repository
{
    internal class RepositoryPAMOCK : IRepositoryPA
    {
        static private List<ProdottoAlimentare> prodottiA = new List<ProdottoAlimentare>() 
        { 
            new ProdottoAlimentare("123",12,"melaa",2,new DateTime(2023,1,1)),
            new ProdottoAlimentare("122",12.22,"pera",4,new DateTime(2023,2,1))
        };

        public ProdottoAlimentare GetTByCode(string id)
        {
            foreach (ProdottoAlimentare itemA in prodottiA)
            {
                if (itemA.Codice == id)
                {
                    return itemA;
                }
            }
            return null;
        }

        public bool Aggiungi(ProdottoAlimentare item)
        {
            if(item == null || GetTByCode(item.Codice) != null)
            {
                Console.WriteLine("Errore nell'inserimento");
                return false;
            }
            
            if (item.DataDiScadenza.Subtract(DateTime.Now).Days <= 0)
            {
                Console.Clear();
                Console.WriteLine("Errore nell'inserimento della data");
                return false;
            }
            prodottiA.Add(item);
            return true;
        }

        public List<ProdottoAlimentare> GetAll()
        {
            return prodottiA;
        }

        public List<ProdottoAlimentare> GetPAAlmostExp()
        {
            List<ProdottoAlimentare> filteredPA = new List<ProdottoAlimentare>();
            foreach (ProdottoAlimentare item in prodottiA)
            {
                if (item.GiorniAllaScadenza < 3)
                {
                    filteredPA.Add(item);
                }
            }
            return filteredPA;
        }

        public List<ProdottoAlimentare> GetPAExp()
        {
            List<ProdottoAlimentare> filteredPA = new List<ProdottoAlimentare>();
            foreach (ProdottoAlimentare item in prodottiA)
            {
                if (item.GiorniAllaScadenza <= 0)
                {
                    filteredPA.Add(item);
                }
            }
            return filteredPA;
        }

        public bool IsVuota()
        {
            return (prodottiA.Count == 0);
        }
    }
}
