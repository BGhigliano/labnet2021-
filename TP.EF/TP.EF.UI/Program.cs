﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using TP4.EF.Logic;
using TP.EF.UI.Extensions;



namespace TP.EF.UI
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
            Console.WriteLine("TP 4 NetLab 2021");
            Console.WriteLine("Seleccionar acción:\n");
            Console.WriteLine("1) Obtener listado de shippers");
            Console.WriteLine("2) Obtener listado de suppliers");
            Console.WriteLine("3) Añadir shipper");
            Console.WriteLine("4) Añadir supplier");
            Console.WriteLine("5) Eliminar shipper");
            Console.WriteLine("6) Eliminar supplier");
            Console.WriteLine("7) Actualizar shipper");
            Console.WriteLine("8) Actualizar supplier");
            Console.WriteLine("9) Finalizar programa");

            switch (Console.ReadLine())
            {
                case "1":
                    ListarShippers();
                    break;
                 case "2":
                    ListarSuppliers();
                    break;
                case "3":
                    AniadirShipper();
                    break;
                case "4":
                    AniadirSupplier();
                    break;
                case "5":
                    EliminarShippers();
                    break;
                case "6":
                    EliminarSuppliers();
                    break;
                case "7":
                    ActualizarShipper();
                    break;
                case "8":
                    ActualizarSupplier();
                    break;
                case "9":
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
        public static void ListarShippers()
        {
                ShippersLogic shippersLogic = new ShippersLogic();
                List<Shippers> listado = shippersLogic.GetAll().ToList();
                Console.WriteLine("Listado de shippers:");
                
                foreach(Shippers s in listado)
                {
                    Console.WriteLine($"Id: {s.ShipperID}, empresa: {s.CompanyName}, teléfono: {s.Phone}");
                }

                Console.WriteLine("Presione una tecla para retornar al menú principal");
                Console.ReadKey();
           
        }
        public static void ListarSuppliers()
        {
                SuppliersLogic suppliersLogic = new SuppliersLogic();
                List<Suppliers> listado = suppliersLogic.GetAll().ToList();
                Console.WriteLine("Listado de suppliers:");

                // Se toman 3 propiedades de la entidad suppliers para simplificar el ejemplo

                foreach (Suppliers s in listado)
                {
                    Console.WriteLine($"Id: {s.SupplierID}, empresa: {s.CompanyName}, contacto: {s.ContactName}, título del contacto: {s.ContactTitle}");
                }

                Console.WriteLine("Presione una tecla para retornar al menú principal");
                Console.ReadKey();
        }
        public static void AniadirShipper()
        {
            do
            {
                ShippersLogic shippersLogic = new ShippersLogic();
                Shippers nuevoShipper = new Shippers();
             
                try
                {
                    Console.WriteLine("Escriba el nombre de la empresa:");
                    string nombreEmpresa = Console.ReadLine();
                    nuevoShipper.CompanyName = nombreEmpresa;

                    Console.WriteLine("Escriba el teléfono de la empresa:");
                    string telefonoEmpresa = Console.ReadLine();
                    nuevoShipper.Phone = telefonoEmpresa;

                    shippersLogic.Add(nuevoShipper);
                }
              
                catch  (DbEntityValidationException e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }
                
                Console.WriteLine("Shipper añadido, presione una tecla para continuar");

                Console.ReadKey();
                break;
            }
            while (true);
                
        }
        public static void AniadirSupplier()
        {


            /// Se completan sólo 3 parámetros para simplificar el ejemplo
            /// 


            do
            {
                SuppliersLogic suppliersLogic= new SuppliersLogic();
                Suppliers nuevoSupplier = new Suppliers();


                try
                {
                    Console.WriteLine("Escriba el nombre de la empresa:");
                    string nombreEmpresa = Console.ReadLine();
                    nuevoSupplier.CompanyName = nombreEmpresa;

                    Console.WriteLine("Escriba el nombre del contacto:");
                    string nombreContacto = Console.ReadLine();
                    nuevoSupplier.ContactName = nombreContacto;

                    Console.WriteLine("Escriba el título del contacto:");
                   string tituloContacto = Console.ReadLine();
                    nuevoSupplier.ContactTitle = tituloContacto;

                    suppliersLogic.Add(nuevoSupplier);
                }

                catch (DbEntityValidationException e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }

                Console.WriteLine("Supplier añadido, presione una tecla para continuar");

                Console.ReadKey();
                break;
            }
            while (true);

        }
        public static void EliminarShippers()
        {
            do
            {
                ShippersLogic shippersLogic = new ShippersLogic();
               
                Console.WriteLine("Indique el Id del shipper a eliminar:");
                try
                {
                    int id =Int32.Parse(Console.ReadLine());
                    shippersLogic.Delete(id);
                }

                catch(Exception e)
                {
                  e.ResumenErroresValidacion();
                    continue;
                }
                Console.WriteLine("Shipper eliminado, presione una tecla para continuar");

                Console.ReadKey();
                break;

            }
            while (true);
         }
        public static void EliminarSuppliers()
        {
            do
            {
                SuppliersLogic suppliersLogic = new SuppliersLogic();
                

                Console.WriteLine("Indique el Id del supplier a eliminar:");
                try
                {
                    int id = Int32.Parse(Console.ReadLine());
                    suppliersLogic.Delete(id);
                }

                catch (Exception e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }

                Console.WriteLine("Supplier eliminado, presione una tecla para continuar");

                Console.ReadKey();
                break;
            }
            while (true);
        }
        public static void ActualizarShipper()
        {
            do
            {
                ShippersLogic shippersLogic = new ShippersLogic();


                try
                {
                    Console.WriteLine("Indique el Id del shipper a modificar:");

                    int id = Int32.Parse(Console.ReadLine());
                    Shippers shipper = shippersLogic.Busqueda(id);
                    
                    Console.WriteLine("Indique el nuevo nombre del shipper o ingrese la letra n para evitar cargar un nuevo nombre:");

                    string nuevoNombre = Console.ReadLine();
                    if(nuevoNombre!="n")
                    {
                        shipper.CompanyName = nuevoNombre;
                    }

                    Console.WriteLine("Indique el nuevo teléfono del shipper o ingrese la letra n para evitar cargar un nuevo nombre:");

                    string nuevoTelefono= Console.ReadLine();
                    if (nuevoTelefono != "n")
                    {
                        shipper.Phone = nuevoTelefono;
                    }
                    shippersLogic.Update(shipper);
                }

                catch (DbEntityValidationException e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }
                catch(Exception e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }

                Console.WriteLine("Shipper modificado, presione una tecla para continuar");

                Console.ReadKey();
                break;

            }
            while (true);

            }
        public static void ActualizarSupplier()
        {
            SuppliersLogic suppliersLogic = new SuppliersLogic();

            do
            {
                try
                {
                    Console.WriteLine("Indique el Id del supplier a modificar:");

                    int id = Int32.Parse(Console.ReadLine());
                    Suppliers supplier = suppliersLogic.Busqueda(id);

                    Console.WriteLine("Indique el nuevo nombre del supplier o ingrese la letra n para evitar cargar un nuevo nombre:");

                    string nuevoNombre = Console.ReadLine();
                    if (nuevoNombre != "n")
                    {
                        supplier.CompanyName = nuevoNombre;
                    }

                    Console.WriteLine("Indique el nuevo contacto del supplier o ingrese la letra n para evitar cargar un nuevo nombre:");

                    string nuevoContacto = Console.ReadLine();
                    if (nuevoContacto != "n")
                    {
                        supplier.ContactName = nuevoContacto;
                    }

                    Console.WriteLine("Indique el nuevo título del contacto o ingrese la letra n para evitar cargar un nuevo nombre:");

                    string nuevoTitulo = Console.ReadLine();
                    if (nuevoTitulo != "n")
                    {
                        supplier.ContactTitle = nuevoTitulo;
                    }

                    suppliersLogic.Update(supplier);
                }

                catch (DbEntityValidationException e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }
                catch (Exception e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }

                Console.WriteLine("Supplier modificado, presione una tecla para continuar");

                Console.ReadKey();
                break;

            }


            while (true) ;
        }
          
         
    

    }
}
