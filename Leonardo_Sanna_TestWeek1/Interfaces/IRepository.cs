using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna_TestWeek1.Interfaces
{
    internal interface IRepository <T>
    {
        /// <summary>
        /// Restituisce tutti gli elementi della lista
        /// </summary>
        /// <returns>Una lista di tipo T</returns>
        List<T>? GetAll();
        /// <summary>
        /// Aggiunge un item alla repository
        /// </summary>
        /// <param name="item">item di tipo T generico</param>
        /// <returns>true se è andato tutto a buon fine, false altrimenti</returns>
        bool Aggiungi(T item);
        /// <summary>
        /// Controlla se la lista di elementi è vuota
        /// </summary>
        /// <returns>true se la lista è vuota, false altrimenti</returns>
        bool IsVuota();
        /// <summary>
        /// Ricerca dell'elemento per id
        /// </summary>
        /// <param name="id">id dell'elemento da cercare</param>
        /// <returns>L'elemento di tipo T con quel'id se è presente, null altrimenti</returns>
        T? GetTByCode(string id);


    }
}
