using System;

namespace ejercicio_2_poo
{
   public class ExcepcionPersonalizada:Exception
    {
        public ExcepcionPersonalizada(string mensaje) : base(mensaje)
        {

        }

        public ExcepcionPersonalizada(string mensaje, string sobrecarga) : base($"{mensaje} {sobrecarga}")
        {

        }
    }
}
