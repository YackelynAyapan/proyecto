
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbolBinarioOrdenado1
{

    public class ArbolBinarioOrdenado

    {
        //static int[] nombres = new int [10];
        static string[] Nombres = new string[5000];
        static string[] Apellido = new string[5000];
        static string[] Telefono = new string[5000];
        static string[] Correo = new string[5000];
        static int buscar;
        static int Opcion = 0;
        static int contador = 1;
        static int[] Codigo = new int[5000];


        class Nodo
        {
            public int info;
            public Nodo izq, der;
        }
        Nodo raiz;

        public ArbolBinarioOrdenado()
        {
            raiz = null;
        }

        public void Insertar(int info)
        {
            Nodo nuevo;
            nuevo = new Nodo();
            nuevo.info = info;
            nuevo.izq = null;
            nuevo.der = null;
            if (raiz == null)
                raiz = nuevo;
            else
            {
                Nodo anterior = null, reco;
                reco = raiz;
                while (reco != null)
                {
                    anterior = reco;
                    if (info < reco.info)
                        reco = reco.izq;
                    else
                        reco = reco.der;
                }
                if (info < anterior.info)
                    anterior.izq = nuevo;
                else
                    anterior.der = nuevo;
            }
        }


        private void ImprimirPre(Nodo reco)
        {
            if (reco != null)
            {
                Console.Write(reco.info + " ");
                ImprimirPre(reco.izq);
                ImprimirPre(reco.der);
            }
        }

        public void ImprimirPre()
        {
            ImprimirPre(raiz);
            Console.WriteLine();
        }

        private void ImprimirEntre(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirEntre(reco.izq);
                Console.Write(reco.info + " ");
                ImprimirEntre(reco.der);
            }
        }

        public void ImprimirEntre()
        {
            ImprimirEntre(raiz);
            Console.WriteLine();
        }


        private void ImprimirPost(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirPost(reco.izq);
                ImprimirPost(reco.der);
                Console.Write(reco.info + " ");
            }
        }


        public void ImprimirPost()
        {
            ImprimirPost(raiz);
            Console.WriteLine();
        }


        //public void buscar()
        //{
        //    if (raiz == null)
        //    {
        //        Console.WriteLine("El arbol esta vacio");

        //    }
        //    else if (raiz == ese) {
        //        Console.WriteLine( "se encontro el valor buscado"+ese);

        //    }

        //}


        //public void addContacto()
        //{   Console.WriteLine("----------Creacion de un nuevo contacto---------");
        //    Console.WriteLine("ingrese contacto a insertar");
        //    Console.WriteLine("Su Codigo es: "+contador);

        //    Console.WriteLine("Nombre:");
        //    Nombres[contador] = Console.ReadLine();
        //    Console.WriteLine("Apellido:");
        //    Apellido[contador] = Console.ReadLine();
        //    Console.WriteLine("Telefono:");
        //    Telefono[contador] = Console.ReadLine();
        //    Console.WriteLine("Correo:");
        //    Correo[contador] = Console.ReadLine();
        //    contador = contador + 1;


        //}
        //public void buscarContacto()
        //{
        //    Console.WriteLine("----------Busqueda de Contactos---------");
        //    Console.Write("Ingrese el Codigo:");
        //    buscar = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Buscando.......");
        //    Console.WriteLine("Nombre: "+Nombres[buscar]+"\n"+"Apellido: "+Apellido[buscar] + "\n" +"telefono: "+ Telefono[buscar] + "\n" +"Correo: "+
        //        Correo[buscar]);


        //}



        static void Main(string[] args)
        {   

            
               

            do
            {
                ArbolBinarioOrdenado abo = new ArbolBinarioOrdenado();


                Console.WriteLine("===================================");
                Console.WriteLine("    Administrador de Contactos    ");
                Console.WriteLine("===================================");
                Console.WriteLine("1.Crear nuevo Contacto:");
                Console.WriteLine("2.Buscar Contacto:");
                Console.WriteLine("Editar contacto:");
                Console.WriteLine("Eliminar Contacto");
                Console.WriteLine("\tIngrese su opcion: ");
                Opcion = int.Parse(Console.ReadLine());

                switch (Opcion)
                {
                    case 1:
                        Console.WriteLine("----------Creacion de un nuevo contacto---------");
                        Console.WriteLine("Ingrese contacto a insertar");
                       

                        Random rnd1 = new Random();
                        Codigo[contador] = rnd1.Next(5000);

                        abo.Insertar(Codigo[contador]);
                       
                        Console.WriteLine("Su Codigo es:"+ Codigo[contador]);
                        

                        Console.WriteLine("Nombre:");
                        Nombres[Codigo[contador]] = Console.ReadLine();
                        Console.WriteLine("Apellido:");
                        Apellido[Codigo[contador]] = Console.ReadLine();
                        Console.WriteLine("Telefono:");
                        Telefono[Codigo[contador]] = Console.ReadLine();
                        Console.WriteLine("Correo:");
                        Correo[Codigo[contador]] = Console.ReadLine();
                        contador = contador + 1;


                        

                        break;
                    case 2:
                        Console.WriteLine("----------Busqueda de Contactos---------");
                        Console.Write("Ingrese el Codigo:");
                        buscar = int.Parse(Console.ReadLine());

                        Console.WriteLine("Buscando.......");
                        Console.WriteLine("Nombre: " + Nombres[buscar] + "\n" + "Apellido: " + Apellido[buscar] + "\n" + "telefono: " + Telefono[buscar] + "\n" + "Correo: " +
                        Correo[buscar]);
                        Console.WriteLine("Impresion preorden: ");
                        abo.ImprimirPre();
                        Console.WriteLine("Impresion entreorden: ");
                        abo.ImprimirEntre();
                        Console.WriteLine("Impresion postorden: ");
                        abo.ImprimirPost();
                        Console.ReadKey();

                        break;
                    case 3:
                        Console.WriteLine("Saliendo del programa......");
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;

                }
            } while (Opcion != 3);
            //Console.ReadLine();

            //Console.WriteLine("ingrese contacto a insertar");
            //nombres[1] = int.Parse(Console.ReadLine());
            //abo.Insertar(nombres[1]);
            //Console.WriteLine("ingrese contacto a insertar");
            //nombres[2] = int.Parse(Console.ReadLine());
            //abo.Insertar(nombres[2]);
            //Console.WriteLine("ingrese contacto a insertar");
            //nombres[3] = int.Parse(Console.ReadLine());
            //abo.Insertar(nombres[3]);
            //Console.WriteLine("ingrese contacto a insertar");
            //nombres[4] = int.Parse(Console.ReadLine());
            //abo.Insertar(nombres[4]);

            //Console.WriteLine("Impresion preorden: ");
            //abo.ImprimirPre();
            //Console.WriteLine("Impresion entreorden: ");
            //abo.ImprimirEntre();
            //Console.WriteLine("Impresion postorden: ");
            //abo.ImprimirPost();
            Console.ReadKey();
        }


    }
    }



