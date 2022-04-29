using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna_TestWeek1.Entities
{
    public class ProdottoTecnologico : Prodotto
    {
        public string Marca { get; set; }
        public bool  IsNew{ get; set; }

        public ProdottoTecnologico()
        {

        }
        public ProdottoTecnologico(string codice, double prezzo, string descrizione, string marca, bool isnew ) : base(codice, prezzo, descrizione)
        {
            Marca = marca;
            IsNew = isnew;
        }

        public override void Informazioni()
        {
            base.Informazioni();
            Console.WriteLine($"marca\t\t{Marca}\t stato\t\t{(IsNew?"nuovo":"usato")}");
        }

    }
}
