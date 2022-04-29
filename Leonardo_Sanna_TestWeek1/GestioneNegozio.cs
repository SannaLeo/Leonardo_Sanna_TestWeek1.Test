using Leonardo_Sanna_TestWeek1.Entities;
using Leonardo_Sanna_TestWeek1.Interfaces;
using Leonardo_Sanna_TestWeek1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna_TestWeek1
{
    internal class GestioneNegozio
    {
        //static IRepository<ProdottoAlimentare> repoPA = new RepositoryPAMOCK();
        static IRepository<ProdottoTecnologico> repoPT = new RepositoryPTMOCK();
        static IRepository<ProdottoAlimentare> repoPA = new RepositoryProdottiAlimentariFile();
        public static void Start()
        {
            bool continua = true;
            while (continua) // continua==true
            {
                int scelta = Menu();
                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        VisualizzaTuttiIProdotti();
                        break;
                    case 2:
                        Console.Clear();
                        VisualizzaAlimentari();
                        break;
                    case 3:
                        Console.Clear();
                        VisualizzaTecnologici();
                        break;
                    case 4:
                        Console.Clear();
                        AggiungiProdottoAlimentare();
                        break;
                    case 5:
                        Console.Clear();
                        AggiungiProdottoTecnologico();
                        break;
                    case 6:
                        Console.Clear();
                        CercaProdottoAlimentarePerCodice();
                        break;
                    case 7:
                        Console.Clear();
                        CercaProdottoTecnologicoPerMarca();
                        break;
                    case 8:
                        Console.Clear();
                        VisualizzaProdottiTecnologiciNuovi();
                        break;
                    case 9:
                        Console.Clear();
                        VisualizzaAlimentariScadutiOggi();
                        break;
                    case 10:
                        Console.Clear();
                        VisualizzaProdottiscadutiDaGiorni(3);
                        break;
                    case 0:
                        continua = false;
                        Console.WriteLine("Arrivederci");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Scelta errata.");
                        break;
                }
            }
        }
        /// <summary>
        /// Visualizza i prodotti scaduti oggi
        /// </summary>
        private static void VisualizzaAlimentariScadutiOggi()
        {
            VisualizzaProdottiscadutiDaGiorni(0);
        }
        /// <summary>
        /// Visualizza solo i prodotti scaduti da n giorni
        /// </summary>
        /// <param name="giorni">int giorni dalla scadenza del prodotto</param>
        private static void VisualizzaProdottiscadutiDaGiorni(int giorni)
        {
            var prodotti = repoPA.GetAll();
            if(prodotti == null)
            {
                Console.WriteLine("Non ci sono prodotti");
                return;
            }
            if(prodotti.Count() == 0){
                Console.WriteLine("Non ci sono Alimenti");
                return;
            }
            foreach(var p in prodotti)
            {
                if(p.GiorniAllaScadenza == giorni)
                {
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                    p.Informazioni();
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                }
            }
        }
        /// <summary>
        /// Visualizza solo i prodotti tecnologici nuovi
        /// </summary>
        private static void VisualizzaProdottiTecnologiciNuovi()
        {
            var prodotti = repoPT.GetAll();
            if (prodotti == null)
            {
                Console.WriteLine("Non ci sono prodotti");
                return;
            }
            foreach (var p in prodotti)
            {
                if (p.IsNew)
                {
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                    p.Informazioni();
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                }
            }
        }
        /// <summary>
        /// Cerca un prodotto tecnologico per marca
        /// </summary>
        private static void CercaProdottoTecnologicoPerMarca()
        {
            string? marca;
            Console.WriteLine("Inserisci la marca da cercare ");
            marca = Console.ReadLine();
            while (string.IsNullOrEmpty(marca))
            {
                Console.WriteLine("Inserisci la marca da cercare ");
                marca = Console.ReadLine();
            }
            var prodotti = repoPT.GetAll();
            if(prodotti == null)
            {
                Console.WriteLine("Nessun prodotto tecnologico in da cercare");
                return;
            }
            foreach(var p in prodotti)
            {
                if(p.Marca == marca)
                {
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                    p.Informazioni();
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                }
            }
            
        }
        /// <summary>
        /// Cerca un prodotto alimentare per il codice
        /// </summary>
        private static void CercaProdottoAlimentarePerCodice()
        {
            string? codice;
            ProdottoAlimentare? find;
            Console.WriteLine("Inserisci il codice del prodotto da cercare");
            codice = Console.ReadLine();
            while(string.IsNullOrEmpty(codice))
            {
                Console.WriteLine("Inserisci il codice del prodotto da cercare");
                codice = Console.ReadLine();
            }
            find = repoPA.GetTByCode(codice);
            if(find == null)
            {
                Console.WriteLine("Prodotto non trovato!");
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------------------------------------");
                find.Informazioni();
                Console.WriteLine("---------------------------------------------------------------------------------------");
            }
        }
        /// <summary>
        /// Aggiunge un nuovo prodotto alimentare
        /// </summary>
        private static void AggiungiProdottoAlimentare()
        {
            string? codice, descrizione;
            double prezzo;
            DateTime datat;
            int quantita;
            do
            {
                Console.WriteLine("Inserisci il codice del prodotto ");
                codice = Console.ReadLine();
                while (string.IsNullOrEmpty(codice))
                {
                    Console.WriteLine("Inserisci un codice valido");
                    codice = Console.ReadLine();
                }
                Console.WriteLine("Inserisci il prezzo del prodotto ");
                while (!double.TryParse(Console.ReadLine(), out prezzo))
                {
                    Console.WriteLine("Inserisci un valore valido");
                }
                Console.WriteLine("Inserisci una breve descrizione del prodotto ");
                descrizione = Console.ReadLine();
                while (string.IsNullOrEmpty(descrizione))
                {
                    Console.WriteLine("Inserisci una descrizione valida");
                    descrizione = Console.ReadLine();
                }
                Console.WriteLine("Inserisci la quantita' del prodotto ");
                while (!int.TryParse(Console.ReadLine(), out quantita))
                {
                    Console.WriteLine("Inserisci un valore valido");
                }
                Console.WriteLine("Inserisci l'anno il mese e il giorno di scadenza (es 2022/3/2) ");
                while (!DateTime.TryParse(Console.ReadLine(), out datat))
                {
                    Console.WriteLine("Inserisci un valore valido");
                }
            } while (!repoPA.Aggiungi(new ProdottoAlimentare(codice, prezzo, descrizione, quantita, datat)));
        }
        /// <summary>
        /// Aggiungi un nuovo prodotto tecnologico
        /// </summary>
        private static void AggiungiProdottoTecnologico()
        {
            string? codice, descrizione, marca, stato;
            double prezzo;
            bool cicla = true, statob = true;
            do
            {
                Console.WriteLine("Inserisci il codice del prodotto ");
                codice = Console.ReadLine();
                while (string.IsNullOrEmpty(codice))
                {
                    Console.WriteLine("Inserisci un codice valido");
                    codice = Console.ReadLine();
                }
                Console.WriteLine("Inserisci il prezzo del prodotto ");
                while (!double.TryParse(Console.ReadLine(), out prezzo))
                {
                    Console.WriteLine("Inserisci un valore valido");
                }
                Console.WriteLine("Inserisci una breve descrizione del prodotto ");
                descrizione = Console.ReadLine();
                while (string.IsNullOrEmpty(descrizione))
                {
                    Console.WriteLine("Inserisci una descrizione valida");
                    descrizione = Console.ReadLine();
                }
                Console.WriteLine("Inserisci la marca del prodotto ");
                marca = Console.ReadLine();
                while (string.IsNullOrEmpty(marca))
                {
                    Console.WriteLine("Inserisci una marca valida");
                    marca = Console.ReadLine();
                }
                Console.WriteLine("Inserisci lo stato del prodotto del prodotto (usato/nuovo)");
                stato = Console.ReadLine();
                while (cicla)
                {
                    if (stato != null)
                    {
                        stato = stato.ToLower();
                    }
                    
                    if (stato == "nuovo")
                    {
                        statob = true;
                        cicla = false;
                    }
                    else if (stato == "usato")
                    {
                        statob = false;
                        cicla = false;
                    }
                    else
                    {
                        cicla = true;
                        Console.WriteLine("Inserisci un valore valido");
                        stato = Console.ReadLine();
                    }
                }
            } while (!repoPT.Aggiungi(new ProdottoTecnologico(codice, prezzo, descrizione, marca, statob)));
        }
        /// <summary>
        /// Mostra tutti i prodotti
        /// </summary>
        private static void VisualizzaTuttiIProdotti()
        {
            bool prodottiA, prodottiT;
            prodottiA = repoPA.IsVuota();
            prodottiT = repoPT.IsVuota();
            if (prodottiA && prodottiT)
            {
                Console.WriteLine("Nessun prodotto nel negozio");
                return;
            }
            VisualizzaAlimentari();
            VisualizzaTecnologici();
        }
        /// <summary>
        /// Mostra a schermo tutti i Prodotti Alimentari
        /// </summary>
        public static void VisualizzaAlimentari()
        {
            var alimentari = repoPA.GetAll();
            if(alimentari == null)
            {
                return;
            }
            foreach (ProdottoAlimentare p in alimentari)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------");
                p.Informazioni();
                Console.WriteLine("---------------------------------------------------------------------------------------");
            }
            
        }
        /// <summary>
        /// Mostra a schermo tutti i Prodotti Tecnologici
        /// </summary>
        public static void VisualizzaTecnologici()
        {
            var tecnologici = repoPT.GetAll();
            if(tecnologici == null)
            {
                return;
            }
            foreach (ProdottoTecnologico p in tecnologici)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------");
                p.Informazioni();
                Console.WriteLine("---------------------------------------------------------------------------------------");
            }
        }
        /// <summary>
        /// Visualizza il menu e restituisce la scelta dell'utente
        /// </summary>
        /// <returns>int scelta dell'utente</returns>
        private static int Menu()
        {
            Console.WriteLine("---------------MENU----------");
            Console.WriteLine("1. Visualizza tutti i Prodotti");
            Console.WriteLine("2. Visualizza tutti i Prodotti Alimentari");
            Console.WriteLine("3. Visualizza tutti i Prodotti Tecnologici");
            Console.WriteLine("4. Aggiungi un nuovo Prodotto Alimentare");
            Console.WriteLine("5. Aggiungi un nuovo Prodotto Tecnologico");
            Console.WriteLine("6. Cerca Prodotto Alimentare per Codice");
            Console.WriteLine("7. Cerca Prodotto Tecnologico per Marca");
            Console.WriteLine("8. Visualizza tutti i Prodotti Tecnologici nuovi");
            Console.WriteLine("9. Visualizza tutti i Prodotti Alimentari in scadenza oggi");
            Console.WriteLine("10.Visualizza tutti i Prodotti Alimentari che scadono tra meno di tre giorni");
            Console.WriteLine("\n0.Exit");
            Console.WriteLine("\nInserisci la tua scelta:");
            int sceltaUtente;
            while (!(int.TryParse(Console.ReadLine(), out sceltaUtente)))
            {
                Console.WriteLine("Riprova. Devi inserire un numero intero.");
            }
            return sceltaUtente;
        }
    }
}
