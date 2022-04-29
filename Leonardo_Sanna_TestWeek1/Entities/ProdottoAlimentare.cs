using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna_TestWeek1.Entities
{
    public class ProdottoAlimentare : Prodotto
    {
        public int QuantitaInMagazzino { get; private set; }
        public DateTime DataDiScadenza { get; private set; }
        public int GiorniAllaScadenza { get; private set; }


        public ProdottoAlimentare(string codice, double prezzo, string descrizione, int quantita, DateTime dataDiScadenza) : base(codice, prezzo, descrizione)
        {
            QuantitaInMagazzino = quantita;
            DataDiScadenza = dataDiScadenza;
            GiorniAllaScadenza = DataDiScadenza.Subtract(DateTime.UtcNow).Days;
        }
        /// <summary>
        /// Mostra le informazioni del prodotto alimentare
        /// </summary>
        public override void Informazioni()
        {
            base.Informazioni();
            Console.WriteLine($"quantità\t{QuantitaInMagazzino}\t scadenza\t{DataDiScadenza.ToShortDateString()}\t{(GiorniAllaScadenza <= 0 ? "scaduto" : $"scade tra \t{GiorniAllaScadenza} {(GiorniAllaScadenza==1?" giorno":"giorni")}")}");
        }
    }
}
