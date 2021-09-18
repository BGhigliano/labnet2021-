using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.EF.UI.Extensions
{
    public static class ExceptionExtension
    {
         public static void ResumenErroresValidacion(this Exception e)
       {
           Console.WriteLine($"Se detectó la siguiente excepción:");

           Console.WriteLine($"\"{e.Message}\"");

           Console.WriteLine("Presione una tecla para intentar nuevamente");

           Console.ReadKey();
       }

    }
}
