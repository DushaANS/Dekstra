using System;

class DijkstraAlgorithm
{
    static void Main()
    {
        // Создаем граф
        int[,] graph = new int[,] {
{ 0, 2, 4, 0, 0 },
{ 2, 0, 3, 6, 0 },
{ 4, 3, 0, 1, 5 },
{ 0, 6, 1, 0, 2 },
{ 0, 0, 5, 2, 0 }
};

        // Вызываем алгоритм Дейкстры
        int[] distances = Dijkstra(graph, 0);

        // Выводим результаты
        Console.WriteLine("Расстояния до вершин:");
        for (int i = 0; i < distances.Length; i++)
        {
            Console.WriteLine("{0}: {1}", i, distances[i]);
        }
    }

    // Алгоритм Дейкстры
    static int[] Dijkstra(int[,] graph, int start)
    {
        int n = graph.GetLength(0);
        int[] distances = new int[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }

        distances[start] = 0;

        for (int i = 0; i < n - 1; i++)
        {
            int u = MinDistance(distances, visited);
            visited[u] = true;

            for (int v = 0; v < n; v++)
            {
                if (!visited[v] && graph[u, v] != 0 && distances[u] != int.MaxValue
                && distances[u] + graph[u, v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u, v];
                }
            }
        }

        return distances;
    }

    // Вспомогательный метод для поиска вершины с минимальным расстоянием
    static int MinDistance(int[] distances, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int i = 0; i < distances.Length; i++)
        {
            if (!visited[i] && distances[i] <= min)
            {
                min = distances[i];
                minIndex = i;
            }
        }

        return minIndex;
    }
}
