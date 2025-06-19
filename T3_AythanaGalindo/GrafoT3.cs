using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_AythanaGalindo
{
    internal class GrafoT3
    {
        private double[,] matrizAdyacencia;
        private int numNodos;
        public GrafoT3(int numNodos)
        {
            this.numNodos = numNodos;
            matrizAdyacencia = new double[numNodos, numNodos];

            for (int i = 0; i < numNodos; i++)
            {
                for (int j = 0; j < numNodos; j++)
                {
                    if (i == j)
                        matrizAdyacencia[i, j] = 0;
                    else
                        matrizAdyacencia[i, j] = double.PositiveInfinity;
                }
            }
        }

        public void AgregarArista(int origen, int destino, double peso)
        {
            matrizAdyacencia[origen, destino] = peso;
            matrizAdyacencia[destino, origen] = peso;
        }

        public void Mostrar()
        {
            Console.WriteLine("Matriz de adyacencia:");
            for (int i = 0; i < numNodos; i++)
            {
                for (int j = 0; j < numNodos; j++)
                {
                    if (double.IsPositiveInfinity(matrizAdyacencia[i, j]))
                        Console.Write(" ∞ ");
                    else
                        Console.Write($"{matrizAdyacencia[i, j],3} ");
                }
                Console.WriteLine();
            }
        }

        public int NumGrupos()
        {
            bool[] visitado = new bool[numNodos];
            int grupos = 0;
            for (int i = 0; i < numNodos; i++)
            {
                if (!visitado[i])
                {
                    grupos++;
                    DFS(i, visitado);
                }
            }
            return grupos;
        }

        public bool GrupoCorrelativo(int nodo)
        {
            List<int> grupo = new List<int>();
            bool[] visitado = new bool[numNodos];

            DFSCollect(nodo, visitado, grupo);

            grupo.Sort();

            for (int i = 1; i < grupo.Count; i++)
            {
                if (grupo[i] != grupo[i - 1] + 1)
                    return false;
            }
            return true;
        }

        private void DFS(int nodo, bool[] visitado)
        {
            visitado[nodo] = true;

            for (int i = 0; i < numNodos; i++)
            {
                if (matrizAdyacencia[nodo, i] != double.PositiveInfinity && matrizAdyacencia[nodo, i] != 0 && !visitado[i])
                {
                    DFS(i, visitado);
                }
            }
        }

        private void DFSCollect(int nodo, bool[] visitado, List<int> grupo)
        {
            visitado[nodo] = true;
            grupo.Add(nodo);

            for (int i = 0; i < numNodos; i++)
            {
                if (matrizAdyacencia[nodo, i] != double.PositiveInfinity && matrizAdyacencia[nodo, i] != 0 && !visitado[i])
                {
                    DFSCollect(i, visitado, grupo);
                }
            }

        }

    }
}



