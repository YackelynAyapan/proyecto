using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles
{
    
    class NodoT
    {   
        public NodoT NodoIzquierdo;
        public int Informacion;
        public NodoT NodoDerecho;
        //Constructor
        public NodoT()
        {
            this.NodoIzquierdo = null;
            this.Informacion = 0;
            this.NodoDerecho = null;
        }
    }

    class Program
    {
        //Almacenamiento 
        static string[] Nombres = new string[5000];
        static string[] Apellido = new string[5000];
        static string[] Telefono = new string[5000];
        static string[] Correo = new string[5000];

        static void Main(string[] args)
        {

            Console.Title = "Administrador de Contactos";


            int Opcion = 0;
            NodoT Raiz = null;
            int Dato;
            do
            {
                Opcion = Menu();
                switch (Opcion)
                {
                    case 1:
                        Console.Write("Nuevo contacto>>> ");

                        Dato = aleatorio();
                        Console.WriteLine("Su codigo es: "+Dato);

                        Console.WriteLine("Nombre:");
                        Nombres[Dato] = Console.ReadLine();
                        Console.WriteLine("Apellido:");
                        Apellido[Dato] = Console.ReadLine();
                        Console.WriteLine("Telefono:");
                        Telefono[Dato] = Console.ReadLine();
                        Console.WriteLine("Correo:");
                        Correo[Dato] = Console.ReadLine();
                       
                        if (Raiz == null)
                        {
                            NodoT NuevoNodo = new NodoT();
                            NuevoNodo.Informacion = Dato;
                            Raiz = NuevoNodo;
                        }
                        else
                        {
                            Insertar(Raiz, Dato);
                        }
                        Console.Clear();
                        break;
                    //Recorrido en Pre Orden del Arbol
                    case 2:
                        RecorridoPreorden(Raiz);
                        Console.WriteLine("Fin del Recorrido,...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    //Recorrido en Post Orden del Arbol
                    case 3:
                        RecorridoPostorden(Raiz);
                        Console.WriteLine("Fin del Recorrido,...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    //Recorrido en In Orden del Arbol
                    case 4:
                        RecorridoInorden(Raiz);
                        Console.WriteLine("Fin del Recorrido,...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Write("Teclee el Contacto a Buscar: ");
                        Dato = int.Parse(Console.ReadLine());
                        if (Raiz != null)
                        {
                            BuscarNodo(Raiz, Dato);
                        }
                        else
                        {
                            Console.WriteLine("ERROR, Arbol Vacio....");
                        }
                        Console.Clear();
                        break;
                    case 6:
                        Console.Write("Teclee el codigo del Contacto a Eliminar: ");
                        Dato = int.Parse(Console.ReadLine());
                        if (Raiz != null)
                        {
                            EliminarNodo(ref Raiz, Dato);
                        }
                        else
                        {
                            Console.WriteLine("ERROR, Arbol Vacio....");
                        }
                        Console.Clear();
                        break;
                    case 7:
                        Finalizar();
                        break;
                }
            } while (Opcion != 7);

        }
        static int Menu()
        {

            int Resultado = 0;
            do
            {
                Console.WriteLine("=================================================");
                Console.WriteLine("                  Mis Contactos                  ");
                Console.WriteLine("=================================================");
                Console.WriteLine("");
                Console.WriteLine("1.- Registrar un contacto nuevo");
                Console.WriteLine("2.- Recorrido en Pre-orden");
                Console.WriteLine("3.- Recorrido en Post-orden");
                Console.WriteLine("4.- Recorrido en In-orden");
                Console.WriteLine("5.- Buscar un Contacto");
                Console.WriteLine("6.- Eliminar un Contacto");
                Console.WriteLine("7.- Finalizar el Programa");
                Console.WriteLine("");
                Console.Write("Teclee la Opcion Deseada: ");
                Resultado = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                if (Resultado < 1 || Resultado > 7)
                {
                    Console.WriteLine("ERROR, Opcion Invalida....");
                    Console.ReadLine();
                    Console.WriteLine("");
                }
                Console.Clear();
            } while (Resultado < 1 || Resultado > 7);
            return Resultado;
        }
        //Insertar en un arbol binario
        static void Insertar(NodoT Raiz, int Dato)
        {
            if (Dato < Raiz.Informacion)
            {
                if (Raiz.NodoIzquierdo == null)
                {
                    NodoT NuevoNodo = new NodoT();
                    NuevoNodo.Informacion = Dato;
                    Raiz.NodoIzquierdo = NuevoNodo;
                }
                else
                {
                    //Llamada recursiva
                    Insertar(Raiz.NodoIzquierdo, Dato);
                }
            }
            else//Buscar por el lado derecho
            {
                if (Dato > Raiz.Informacion)
                {
                    if (Raiz.NodoDerecho == null)
                    {
                        NodoT NuevoNodo = new NodoT();
                        NuevoNodo.Informacion = Dato;
                        Raiz.NodoDerecho = NuevoNodo;
                    }
                    else
                    {
                        //Llamada recursiva por el lado derecho
                        Insertar(Raiz.NodoDerecho, Dato);
                    }
                }
                else
                {
                    //El Nodo existe en el Arbol
                    Console.WriteLine("Contacto Existente, Imposible Insertar...");
                    Console.ReadLine();
                }
            }
        }
        //Metodo de recorrido en Pre-Orden
        static void RecorridoPreorden(NodoT Raiz)
        {
            if (Raiz != null)
            {
                Console.Write("{0}, ", Raiz.Informacion);
                RecorridoPreorden(Raiz.NodoIzquierdo);
                RecorridoPreorden(Raiz.NodoDerecho);
            }
        }
        //Metodo de recorrido en In-Orden
        static void RecorridoInorden(NodoT Raiz)
        {
            if (Raiz != null)
            {
                RecorridoInorden(Raiz.NodoIzquierdo);
                Console.Write("{0}, ", Raiz.Informacion);
                RecorridoInorden(Raiz.NodoDerecho);
            }
        }
        //Metodo de recorrido en Post-Orden
        static void RecorridoPostorden(NodoT Raiz)
        {
            if (Raiz != null)
            {
                RecorridoPostorden(Raiz.NodoIzquierdo);
                RecorridoPostorden(Raiz.NodoDerecho);
                Console.Write("{0}, ", Raiz.Informacion);
            }
        }
        //Metodo de Buscar un nodo
        static void BuscarNodo(NodoT Raiz, int Dato)
        {
            if (Dato < Raiz.Informacion)
            {
                //Buscar por el Sub-Arbol izquierdo
                if (Raiz.NodoIzquierdo == null)
                {
                    Console.WriteLine("ERROR, No se encuentra el Contacto...");
                    Console.ReadLine();
                }
                else
                {
                    BuscarNodo(Raiz.NodoIzquierdo, Dato);
                }
            }
            else
            {
                if (Dato > Raiz.Informacion)
                {
                    //Buscar por el Sub-Arbol derecho
                    if (Raiz.NodoDerecho == null)
                    {
                        Console.WriteLine("ERROR, No se encuentra el Contacto...");
                        Console.ReadLine();
                    }
                    else
                    {
                        BuscarNodo(Raiz.NodoDerecho, Dato);
                    }
                }
                else
                {
                    //El nodo se encontro
                    Console.WriteLine("Contacto Localizado en el Arbol...");
                    Console.WriteLine("Datos del contacto:\n\n      Codigo:"+Dato+"\n\nNombre:"+Nombres[Dato]+"\nApellido: " + Apellido[Dato] + "\nTelefono: " + Telefono[Dato] + "\nCorreo: " + Correo[Dato]);
                    
                    Console.ReadLine();
                   

                }
            }
        }
        //Metodo de Eliminar
        static void EliminarNodo(ref NodoT Raiz, int Dato)
        {
            if (Raiz != null)
            {
                if (Dato < Raiz.Informacion)
                {
                    EliminarNodo(ref Raiz.NodoIzquierdo, Dato);
                }
                else
                {
                    if (Dato > Raiz.Informacion)
                    {
                        EliminarNodo(ref Raiz.NodoDerecho, Dato);
                    }
                    else
                    {
                        //Si lo Encontro
                        Console.WriteLine("Eliminando Contacto....");
                        Console.ReadLine();
                        NodoT NodoEliminar = Raiz;
                        if (NodoEliminar.NodoDerecho == null)
                        {
                            Raiz = NodoEliminar.NodoIzquierdo;
                        }
                        else
                        {
                            if (NodoEliminar.NodoIzquierdo == null)
                            {
                                Raiz = NodoEliminar.NodoDerecho;
                            }
                            else
                            {
                                NodoT AuxiliarNodo = null;
                                NodoT Auxiliar = Raiz.NodoIzquierdo;
                                bool Bandera = false;
                                while (Auxiliar.NodoDerecho != null)
                                {
                                    AuxiliarNodo = Auxiliar;
                                    Auxiliar = Auxiliar.NodoDerecho;
                                    Bandera = true;
                                }
                                Raiz.Informacion = Auxiliar.Informacion;
                                NodoEliminar = Auxiliar;
                                if (Bandera == true)
                                {
                                    AuxiliarNodo.NodoDerecho = Auxiliar.NodoIzquierdo;
                                }
                                else
                                {
                                    Raiz.NodoIzquierdo = Auxiliar.NodoIzquierdo;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("ERROR, EL Contacto no se Encuentra en el Arbol...");
                Console.ReadLine();
            }
        }
        //Metodo de Finalizacion
        static void Finalizar()
        {
            Console.WriteLine("Fin del Programa...");
            Console.ReadLine();
        }
        //Generar numero aleatorio
        static int aleatorio()
        {
            Random rnd1 = new Random();
            int codigo = rnd1.Next(5000);
            return codigo;

        }
    }
}