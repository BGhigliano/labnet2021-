using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labnet2021.tp2
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.Clear();
                Console.WriteLine("LabNet 2021 - TP 2 \n");
                Console.WriteLine("Por favor proceda con la carga de la cantidad de pasajeros de los siguientes omnibus:");

                TransportePublico[] transportes = new TransportePublico[10];


                for (int i = 0;i < 5; i++)
                {
                    Console.WriteLine($"Indique la cantidad de pasajeros del ómnibus N° {i+1} (entre 0 y 30) \n");

                    bool valorCorrecto = false;

                    do
                    {
                        if (int.TryParse(Console.ReadLine(), out int number))
                        {
                            if (number > 30 || number < 0)
                            {
                                Console.WriteLine("Cantidad incorrecta, intente nuevamente");
                                continue;
                            }

                            Omnibus o = new Omnibus();
                            o.Pasajeros = number;
                            transportes[i] = o;
                            valorCorrecto = true;
                        }

                        else
                        {
                            Console.WriteLine("El valor ingresado no es un número apropiado, intente nuevamente");
                            continue;
                        }

                    }
                    while (valorCorrecto == false);
                        
                }
                Console.Clear();

                Console.WriteLine("LabNet 2021 - TP 2 \n");
                Console.WriteLine("Carga de pasajeros de ómnibus concluída, por favor continúe con la carga de pasajeros de los taxis");

                for (int i = 5; i < 10; i++)
                {
                    Console.WriteLine($"Indique la cantidad de pasajeros del taxi N° {i -4} (entre 0 y 4) \n");

                    bool valorCorrecto = false;

                    do
                    {
                        if (int.TryParse(Console.ReadLine(), out int number))
                        {
                            if (number > 4 || number < 0)
                            {
                                Console.WriteLine("Cantidad incorrecta, intente nuevamente");
                                continue;
                            }

                            Omnibus o = new Omnibus();
                            o.Pasajeros = number;
                            transportes[i] = o;
                            valorCorrecto = true;
                        }

                        else
                        {
                            Console.WriteLine("El valor ingresado no es un número apropiado, intente nuevamente");
                            continue;
                        }

                    }
                    while (valorCorrecto == false);

                }




                Console.Clear();
                Console.WriteLine("LabNet 2021 - TP 2 \n");
                Console.WriteLine("Carga finalizada, los valores añadidos son los siguientes: \n");
                for(int i = 0;i<5;i++)
                {
                    Console.WriteLine($"Cantidad de pasajeros del ómnibus N° {i+1}: { transportes[i].Pasajeros}");

                }
                Console.WriteLine();
                for (int i = 5; i < 10; i++)
                {
                    Console.WriteLine($"Cantidad de pasajeros del taxi N° {i-4}: { transportes[i].Pasajeros}");
                }
                Console.WriteLine();
                Console.WriteLine("Presione una tecla para reiniciar la carga");
                Console.ReadKey();

            }

            while (true);


            Console.ReadLine();
        }
    
       
    
    }
}
