using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace графы
{
    public class Graph
    {
        public List<Vertex> v = new List<Vertex>();
        public List<Edge> e = new List<Edge>();
        public double[,] matr;
        public int VertexCount => v.Count;
        public Graph(double[,] matrix)
        {
            createGraph(matrix);
        }
        private void createGraph(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matr = matrix;
                v.Add(new Vertex(i));
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)  
                      e.Add(new Edge(v[i], v[j], matrix[i, j]));
                }
            }
        }
        internal List<Edge> ShortestPath(int v1, int v2)
        {
            double[] d = new double[VertexCount];
            int[] v = new int[VertexCount];
            int minindex;
            double min;
            double temp;
            int begin_index = v1;

            for (int i = 0; i < VertexCount; i++)
            {
                d[i] = Double.PositiveInfinity;
                v[i] = 1;
            }
            d[v1] = 0;
            do
            {
                minindex = int.MaxValue;
                min = Double.PositiveInfinity;
                for (int i = 0; i < VertexCount; i++)
                {
                    if ((v[i] == 1) && (d[i] < min))
                    {
                        min = d[i];
                        minindex = i;
                    }
                }
                // Добавляем найденный минимальный вес
                // к текущему весу вершины
                // и сравниваем с текущим минимальным весом вершины
                if (minindex != int.MaxValue)
                {
                    for (int i = 0; i < VertexCount; i++)
                    {
                        if (matr[minindex, i] > 0)
                        {
                            temp = min + matr[minindex, i];
                            if (temp < d[i])
                            {
                                d[i] = temp;
                            }
                        }
                    }
                    v[minindex] = 0;
                }
            } while (minindex < int.MaxValue);

            int[] ver = new int[VertexCount]; // массив посещенных вершин
            int end = v2; // индекс конечной вершины = 5 - 1
            ver[0] = end + 1; // начальный элемент - конечная вершина
            int k = 1; // индекс предыдущей вершины
            double weight = d[end]; // вес конечной вершины
            if (v[v2] == 1) return null;
            while (end != begin_index) // пока не дошли до начальной вершины
            {
                for (int i = 0; i < VertexCount; i++) // просматриваем все вершины
                    if (matr[i, end] != 0)   // если связь есть
                    {
                        double temp2 = weight - matr[i, end]; // определяем вес пути из предыдущей вершины
                        if (temp2 == d[i]) // если вес совпал с рассчитанным
                        {                 // значит из этой вершины и был переход
                            weight = temp2; // сохраняем новый вес
                            end = i;       // сохраняем предыдущую вершину
                            ver[k] = i + 1; // и записываем ее в массив
                            k++;
                        }
                    }
            }
            List<Edge> path = new List<Edge>();
            for (int i = 0; i < ver.Length - 1; i++)
            {
                if (ver[i + 1] != 0)
                    path.Add(new Edge(this.v[ver[i] - 1], this.v[ver[i + 1] - 1], matr[ver[i] - 1, ver[i + 1] - 1]));
            }
            return path;
        }
    }
}
