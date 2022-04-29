using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo_Sanna_TestWeek1.Interfaces
{
    internal interface IRepository <T>
    {
        List<T> GetAll();
        bool Aggiungi(T item);
        bool IsVuota();
        T GetTByCode(string id);


    }
}
