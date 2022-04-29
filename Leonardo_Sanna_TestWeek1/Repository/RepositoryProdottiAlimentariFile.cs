using Leonardo_Sanna_TestWeek1.Entities;
using Leonardo_Sanna_TestWeek1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna_TestWeek1.Repository
{
    internal class RepositoryProdottiAlimentariFile : IRepositoryPA
    {
        string path = @"D:\Lavoro\lezioni\codice\Leonardo_Sanna_TestWeek1.Test\Leonardo_Sanna_TestWeek1\Repository\Alimentari.txt";

        /// <summary>
        /// Aggiunge un prodotto alimentare al file
        /// </summary>
        /// <param name="item">Un item di tipo <code>Prodotto Alimentare</code></param>
        /// <returns>true se è andato tutto a buon fine</returns>
        public bool Aggiungi(ProdottoAlimentare item)
        {
            if (item == null)
            {
                return false;
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Codice},{item.Prezzo},{item.QuantitaInMagazzino},{item.DataDiScadenza},{item.Descrizione}");
                return true;
            }
            return false;
        }
        /// <summary>
        /// Restituisce la lista presa da file
        /// </summary>
        /// <returns>Lista<ProdottoAlimentare> list se il file contiene degli elementi, List<ProdottoAlimentare> [] altrimenti</returns>
        public List<ProdottoAlimentare> GetAll()
        {
            var list = new List<ProdottoAlimentare>();
            string contenuto;
            using (StreamReader sr = new StreamReader(path))
            {
                contenuto = sr.ReadToEnd();
                if (string.IsNullOrEmpty(contenuto))
                {
                    return list;
                }
                else
                {
                    //ottengo i prodotti
                    var prodotti = contenuto.Split("\r\n");
                    for (int i = 0; i < prodotti.Length-1; i++)
                    {
                        string codice, descrizione;
                        int quantitam;
                        double prezzo;
                        DateTime data;
                        //ottengo i campi del prodotto
                        var prodotto = prodotti[i].Split(',');
                        //Controllo e assegno alle variabili corrispondenti
                        codice = prodotto[0];
                        if(!double.TryParse(prodotto[1], out prezzo))
                        {
                            Console.WriteLine("Errore nel caricamento da file ");
                            return list;
                        }
                        if(!int.TryParse(prodotto[2], out quantitam))
                        {
                            Console.WriteLine("Errore nel caricamento da file ");
                            return list;
                        }
                        if (!DateTime.TryParse(prodotto[3], out data))
                        {
                            Console.WriteLine("Errore nel caricamento da file ");
                            return list; Console.WriteLine("Errore nel caricamento da file ");
                        }
                        descrizione = prodotto[4];
                        //aggiiungo alla lista
                        list.Add(new ProdottoAlimentare(codice,prezzo,descrizione,quantitam,data));
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// Restituisce tutti gli elementi che scadono tra meno di tre giorni
        /// </summary>
        /// <returns>Lista<ProdottoAlimentare> list contenente i prodotti quasi scaduti, List<ProdottoAlimentare> [] altrimenti</returns>
        public List<ProdottoAlimentare> GetPAAlmostExp()
        {
            var list = GetAll();
            var filtered = new List<ProdottoAlimentare>();
            foreach(var item in list)
            {
                if (item.GiorniAllaScadenza <= 3)
                {
                    filtered.Add(item);
                }
            }
            return filtered;
        }
        /// <summary>
        /// Restituisce tutti gli elementi scaduti
        /// </summary>
        /// <returns>Lista<ProdottoAlimentare> list contenente i prodotti scaduti, List<ProdottoAlimentare> [] altrimenti</returns>
        public List<ProdottoAlimentare> GetPAExp()
        {
            var list = GetAll();
            var filtered = new List<ProdottoAlimentare>();
            foreach (var item in list)
            {
                if (item.GiorniAllaScadenza <= 0)
                {
                    filtered.Add(item);
                }
            }
            return filtered;
        }
        /// <summary>
        /// Restituisce il prodotto alimentare con l'id specificato
        /// </summary>
        /// <param name="id">stringa dell'id</param>
        /// <returns>ProdottoAlimentare item se viene trovato, null altrimenti</returns>
        public ProdottoAlimentare GetTByCode(string id)
        {
            var list = GetAll();
            foreach (var item in list)
            {
                if (item.Codice == id)
                {
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        /// Controlla se la lista di elementi è vuota
        /// </summary>
        /// <returns>true se la lista è vuota, false altrimenti</returns>
        public bool IsVuota()
        {
            var list = GetAll();
            return (list.Count == 0);
        }
    }
}
