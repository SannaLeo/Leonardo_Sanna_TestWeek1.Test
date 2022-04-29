using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna_TestWeek1.Entities
{
    public abstract class Prodotto
    {
        public string Codice { get; private set; }
        public string Descrizione { get; private set; }
        public double Prezzo { get; private set; }

        public Prodotto()
        {

        }

        public Prodotto(string codice, double prezzo, string descrizione)
        {
            Codice = codice;
            Prezzo = prezzo;
            Descrizione = descrizione;
        }

        public virtual void Informazioni() 
        {
            Console.WriteLine($"Codice\t\t{Codice}\t prezzo\t\t{Prezzo.ToString("0.00")}\t\tdescrizione\t{Descrizione}\t");
        }
    }
}
