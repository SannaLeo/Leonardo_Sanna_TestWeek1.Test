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
        //lista globale popolata per avere degli elementi all'avvio del programma
        static private List<ProdottoAlimentare> prodottiA = new List<ProdottoAlimentare>() 
        { 
            new ProdottoAlimentare("123",12,"melaa",2,new DateTime(2023,1,1)),
            new ProdottoAlimentare("122",12.22,"pera",4,new DateTime(2023,2,1))
        };
        /// <summary>
        /// Restituisce il prodotto alimentare con l'id specificato
        /// </summary>
        /// <param name="id">stringa dell'id</param>
        /// <returns>ProdottoAlimentare item se viene trovato, null altrimenti</returns>
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
        /// <summary>
        /// Aggiunge un prodotto alimentare alla lista
        /// </summary>
        /// <param name="item">Un item di tipo <code>Prodotto Alimentare</code></param>
        /// <returns>true se è andato tutto a buon fine</returns>
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
        /// <summary>
        /// Restituisce la lista 
        /// </summary>
        /// <returns>Lista<ProdottoAlimentare> list se il file contiene degli elementi, List<ProdottoAlimentare> [] altrimenti</returns>
        public List<ProdottoAlimentare> GetAll()
        {
            return prodottiA;
        }
        /// <summary>
        /// Restituisce tutti gli elementi che scadono tra meno di tre giorni
        /// </summary>
        /// <returns>Lista<ProdottoAlimentare> list contenente i prodotti quasi scaduti, List<ProdottoAlimentare> [] altrimenti</returns>
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
        /// <summary>
        /// Restituisce tutti gli elementi scaduti
        /// </summary>
        /// <returns>Lista<ProdottoAlimentare> list contenente i prodotti scaduti, List<ProdottoAlimentare> [] altrimenti</returns>
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
        /// <summary>
        /// Controlla se la lista di elementi è vuota
        /// </summary>
        /// <returns>true se la lista è vuota, false altrimenti</returns>
        public bool IsVuota()
        {
            return (prodottiA.Count == 0);
        }
    }
}
