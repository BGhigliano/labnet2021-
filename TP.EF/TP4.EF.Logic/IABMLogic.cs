using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.EF.Logic
{
    interface IABMLogic<T>
    {
         List<T> GetAll();
         void Add(T newShippers);
         void Delete(int id);
         void Update(T objetoActualizar);
         T Busqueda(int id);
    }
}
