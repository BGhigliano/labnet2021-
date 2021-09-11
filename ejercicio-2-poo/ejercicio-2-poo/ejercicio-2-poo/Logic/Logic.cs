using System;

namespace ejercicio_2_poo
{
  public  class Logic
    {
        public Exception RetornarExcepcion()
        {
            throw new Exception();
        }
        public Exception RetornarExcepcionPersonalizada(string mensajeBase)
        {
            throw new ExcepcionPersonalizada(mensajeBase);
        }

        public Exception RetornarExcepcionPersonalizada(string mensajeBase, string mensajeSobrecarga)
        {
            throw new ExcepcionPersonalizada(mensajeBase, mensajeSobrecarga);
        }
    }
}
