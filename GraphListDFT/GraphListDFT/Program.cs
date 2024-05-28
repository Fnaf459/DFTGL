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
            Console.Write(current + " ");

            if (adjacencyList.ContainsKey(current))
            {
                foreach (var neighbor in adjacencyList[current])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        stack.Push(neighbor);
                    }
                }
            }
        }

        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Graph graph = new Graph();

        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(2, 6);

        graph.DFS(0);
    }
}
