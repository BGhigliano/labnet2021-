using System;

namespace labnet2021.tp2
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                TransportePublico[] transportes = new TransportePublico[10];

                CargaDeOmnibus(transportes);
                CargaDeTaxis(transportes);
                MuestraDeCarga(transportes);
            }

            while (true);

            void MostrarEncabezado()
            {
                Console.Clear();
                Console.WriteLine("LabNet 2021 - TP 2 \n");
            }

            void CargaDeOmnibus(TransportePublico[] arregloTransporte)
            {
                MostrarEncabezado();

                Console.WriteLine("Por favor proceda con la carga de la cantidad de pasajeros de los siguientes omnibus:");

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Indique la cantidad de pasajeros del ómnibus N° {i + 1} (entre 0 y 30) \n");

                    int cantidadPasajerosInput = ValidacionReadline(30);

                            Omnibus o = new Omnibus(cantidadPasajerosInput);
                         
                            arregloTransporte[i] = o;
               }
                           
            }
          
            void CargaDeTaxis(TransportePublico[] arregloTransporte)
            {
                MostrarEncabezado();

                Console.WriteLine("Carga de pasajeros de ómnibus concluída, por favor continúe con la carga de pasajeros de los taxis");

                for (int i = 5; i < 10; i++)
                {
                    Console.WriteLine($"Indique la cantidad de pasajeros del taxi N° {i - 4} (entre 0 y 4) \n");

                    int cantidadPasajerosInput = ValidacionReadline(4);

                    Taxi t = new Taxi(cantidadPasajerosInput);
                 
                    arregloTransporte[i] = t;
                }

            }
          
            void MuestraDeCarga(TransportePublico[] arregloTransporte)
            {
                MostrarEncabezado();

                Console.WriteLine("Carga finalizada, los valores añadidos son los siguientes: \n");

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Cantidad de pasajeros del ómnibus N° {i + 1}: { arregloTransporte[i].Pasajeros}");

                }
                Console.WriteLine();
                for (int i = 5; i < 10; i++)
                {
                    Console.WriteLine($"Cantidad de pasajeros del taxi N° {i - 4}: { arregloTransporte[i].Pasajeros}");
                }
                Console.WriteLine();
                Console.WriteLine("Presione una tecla para reiniciar la carga");
                Console.ReadKey();
            }
        
            int ValidacionReadline(int cantidadMaxima)
            {
                do
                {
                    if (int.TryParse(Console.ReadLine(), out int number))
                    {

                        if (number > cantidadMaxima || number < 0)
                        {
                            Console.WriteLine("Cantidad incorrecta, intente nuevamente");
                            continue;
                        }

                        else
                        {
                            return number;
                        }
                    }

                    else
                    {
                        Console.WriteLine("El valor ingresado no es un número apropiado, intente nuevamente");
                        continue;
                    }
                }
                while (true);
            }
        }
    }
}
