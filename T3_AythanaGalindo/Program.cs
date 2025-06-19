using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_AythanaGalindo
{
    class Program
    {
        static GrafoT3 grafo = null;
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n   m e n u    ");
                Console.WriteLine("1.  Agregar arista");
                Console.WriteLine("2.  Mostrar matriz");
                Console.WriteLine("3.  Cantidad de grupos");
                Console.WriteLine("4.  Ccorrelativo");
                Console.WriteLine("5.  Salir");

                Console.Write("Seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarArista();
                        break;

                    case 2:
                        MostrarMatriz();
                        break;

                    case 3:
                        MostrarCantidadGrupos();
                        break;

                    case 4:
                        EsCorrelativo();
                        break;

                    case 5:
                        Console.WriteLine("Cerrando");
                        break;

                    default:
                        Console.WriteLine("Ingrese una opcion nvalida.");
                        break;

                }



            } while (opcion != 5);

        }

        static void AgregarArista()
        {

            if (grafo == null)
            {
                Console.Write("Ingrese cantidad de nodos: ");
                int cantidad = int.Parse(Console.ReadLine());
                grafo = new GrafoT3(cantidad);
            }

            Console.Write("Ingrese nodo origen: ");
            int origen = int.Parse(Console.ReadLine());
            Console.Write("Ingrese nodo destino: ");
            int destino = int.Parse(Console.ReadLine());
            Console.Write("Ingrese peso: ");
            double peso = double.Parse(Console.ReadLine());
            grafo.AgregarArista(origen, destino, peso);
            Console.WriteLine("Arista agregada.");
        }

        static void MostrarMatriz()
        {
            if (grafo == null)
            {
                Console.WriteLine("El grafo no ha sido creado.");
                return;
            }

            grafo.Mostrar();
        }

        static void MostrarCantidadGrupos()
        {

            if (grafo == null)
            {
                Console.WriteLine("El grafo no ha sido creado.");

                return;
            }
            int grupos = grafo.NumGrupos();
            Console.WriteLine($"Cantidad de grupos: {grupos}");
        }

        static void EsCorrelativo()
        {
            if (grafo == null)
            {
                Console.WriteLine("El grafo no ha sido creado.");
                return;
            }

            Console.Write("Ingrese nodo: ");
            int nodo = int.Parse(Console.ReadLine());
            bool esCorrelativo = grafo.GrupoCorrelativo(nodo);
            Console.WriteLine($"El grupo es correlativo: {esCorrelativo}");

        }

    }
}



