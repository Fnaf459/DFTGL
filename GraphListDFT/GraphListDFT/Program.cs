using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<int, List<int>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<int, List<int>>();
    }

    public void AddEdge(int source, int destination)
    {
        if (!adjacencyList.ContainsKey(source))
        {
            adjacencyList[source] = new List<int>();
        }
        adjacencyList[source].Add(destination);

        if (!adjacencyList.ContainsKey(destination))
        {
            adjacencyList[destination] = new List<int>();
        }
    }

    public void AddRandomEdges(int numberOfVertices, int numberOfEdges)
    {
        Random random = new Random();

        for (int i = 0; i < numberOfEdges; i++)
        {
            int source = random.Next(numberOfVertices);
            int destination = random.Next(numberOfVertices);

            AddEdge(source, destination);
        }
    }

    public void PrintGraph()
    {
        foreach (var vertex in adjacencyList)
        {
            Console.Write(vertex.Key + ": ");
            foreach (var neighbor in vertex.Value)
            {
                Console.Write(neighbor + " ");
            }
            Console.WriteLine();
        }
    }

    public void DFS(int start)
    {
        List<bool> visited = new List<bool>();

        int maxIndex = -1;
        foreach (var key in adjacencyList.Keys)
        {
            if (key > maxIndex)
            {
                maxIndex = key;
            }
        }
        for (int i = 0; i <= maxIndex; i++)
        {
            visited.Add(false);
        }

        Stack<int> stack = new Stack<int>();

        visited[start] = true;
        stack.Push(start);

        Console.WriteLine("Обход в глубину:");

        while (stack.Count > 0)
        {
            int current = stack.Pop();
            Console.WriteLine("Извлечена " + current);

            Console.Write(current + " ");

            if (adjacencyList.ContainsKey(current))
            {
                foreach (var neighbor in adjacencyList[current])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        stack.Push(neighbor);
                        Console.WriteLine("Добавлена " + neighbor);
                    }
                }
            }
        }

        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Graph graph = new Graph();

        int numberOfVertices = 10;
        int numberOfEdges = 15;

        graph.AddRandomEdges(numberOfVertices, numberOfEdges);

        Console.WriteLine("Список смежности графа:");
        graph.PrintGraph();

        int startVertex = 0;
        graph.DFS(startVertex);
    }
}
