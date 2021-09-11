using ejercicio_2_poo.Extensions;
using System;
using System.Windows.Forms;

namespace ejercicio_2_poo
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                MainMenu();
            }

            while (true);
        }
      
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("TP 2 NetLab 2021");
            Console.WriteLine("Seleccionar acción:\n");
            Console.WriteLine("1) Excepción al dividir por cero");
            Console.WriteLine("2) División de dos números");
            Console.WriteLine("3) Disparador de excepción regular");
            Console.WriteLine("4) Disparador de excepción personalizada");
            Console.WriteLine("5) Finalizar programa");

            switch (Console.ReadLine())
            {
                case "1":
                    DivisionPorCero();
                    break;
                case "2":
                    DivisionRegular();
                    break;
                case "3":
                    DisparadorDeExcepcion();
                    break;
                case "4":
                    DisparadorDeExcepcionPersonalizada();
                    break;
                case "5":
                    Console.WriteLine("Aplicación finalizada, presione un botón para continuar");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                      Console.WriteLine("Valor erróneo, presione una tecla para intentar nuevamente");
                      Console.ReadKey();
                    break;
            }
        }
        public static void DivisionPorCero()
        {
            bool validacionInput = false;
            do
            {
                Console.WriteLine("Ingrese un valor para ser dividido por cero:\n");
                try
                {
                    int dividendo = int.Parse(Console.ReadLine());
                    dividendo.DivisionPorCero();

                }

                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Se divide por cero y se lanza la excepción: {ex.Message}");
                    validacionInput = true;
                }

                catch (Exception)
                {
                    Console.WriteLine($"Valor erróneo, intente nuevamente");
                }
                finally
                {
                    Console.WriteLine("Intento finalizado");
                }
            }
            while (validacionInput == false);
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public static void DivisionRegular()
        {
            bool validacionInput = false;
            do
            {
                try
                {
                    Console.WriteLine("Indique el dividendo");
                    int dividendo = int.Parse(Console.ReadLine());
                    Console.WriteLine("Indique el divisor");
                    int divisor = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Resultado:{dividendo.DivisionConParametros(divisor)}");
                    validacionInput = true;
                }

                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Solo Chuck Norris divide por cero! Mensaje de exepción: {ex.Message}");

                }

                catch (Exception)
                {
                    Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");

                }
                finally
                {
                    Console.WriteLine("Intento finalizado");
                }
            }
            while (validacionInput == false);
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public static void DisparadorDeExcepcion()
        {
            Console.WriteLine("Disparador de exepción seleccionado");
            Logic l = new Logic();

            try
            {
                l.RetornarExcepcion();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
          
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public static void DisparadorDeExcepcionPersonalizada()
        {
            Console.WriteLine("Disparador de exepción personalizada seleccionado");
            Logic l = new Logic();

            try
            {
                Console.WriteLine("Indique el mensaje base de la excepción");
                string argumentoA = Console.ReadLine();
                Console.WriteLine("Indique el agregado al mensaje base de la excepción");
                string argumentoB= Console.ReadLine();
                l.RetornarExcepcionPersonalizada(argumentoA, argumentoB);
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

        }

    }

   
}
