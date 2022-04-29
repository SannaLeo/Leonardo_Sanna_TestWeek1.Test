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

        public bool Aggiungi(ProdottoAlimentare item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Codice},{item.Prezzo},{item.QuantitaInMagazzino},{item.DataDiScadenza},{item.Descrizione}");
            }
            return true;
        }

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
                    var prodotti = contenuto.Split("\r\n");
                    for (int i = 0; i < prodotti.Length-1; i++)
                    {
                        string codice, descrizione;
                        int quantitam;
                        double prezzo;
                        DateTime data;
                        var prodotto = prodotti[i].Split(',');
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
                        list.Add(new ProdottoAlimentare(codice,prezzo,descrizione,quantitam,data));
                    }
                }
            }
            return list;
        }

        public List<ProdottoAlimentare> GetPAAlmostExp()
        {
            var list = GetAll();
            foreach(var item in list)
            {
                if (item.GiorniAllaScadenza <= 3)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public List<ProdottoAlimentare> GetPAExp()
        {
            var list = GetAll();
            foreach (var item in list)
            {
                if (item.GiorniAllaScadenza <= 0)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public ProdottoAlimentare GetTByCode(string id)
        {
            var item = new ProdottoAlimentare();
            
            if (item.Codice == id)
            {
                return item;
            }
            
            return null;
        }

        public bool IsVuota()
        {
            var list = GetAll();
            return (list.Count == 0);
        }
    }
}
