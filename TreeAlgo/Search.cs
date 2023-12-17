using System;
using System.Collections.Generic;

namespace SearchAlgo
{
    public class Search
    {
        public List<Tuple<char, char, int, int>> edges;
        public int vertices;
        public List<char> steps = new List<char>();
        public bool dfsFlag = false;
        public List<Tuple<char, int>> heuristic;
        public int numEnq;
        public List<int> qSteps = new List<int>();

        public Search(int v)
        {
            edges = new List<Tuple<char, char, int, int>>();
            vertices = v;
        }

        public void AddEdge(char v, char w, int weight)
        {
            edges.Add(Tuple.Create(v, w, weight, 0));
        }

        public void BFS(char startVertex, char endVertex)
        {
            Queue<char> q = new Queue<char>();
            bool[] visited = new bool[vertices];

            q.Enqueue(startVertex);
            visited[startVertex - 'A'] = true;
            Console.WriteLine(startVertex);

            while (q.Count > 0)
            {
                qSteps.Add(q.Count);

                char currentVertex = q.Dequeue();
                steps.Add(currentVertex);

                if (currentVertex == endVertex)
                {
                    Console.WriteLine("found");
                    break;
                }

                foreach (var edge in edges)
                {
                    char v = edge.Item1;
                    char w = edge.Item2;
                    int weight = edge.Item3;

                    if (v == currentVertex && !visited[w - 'A'])
                    {
                        q.Enqueue(w);
                        visited[w - 'A'] = true;
                    }
                    else if (w == currentVertex && !visited[v - 'A'])
                    {
                        q.Enqueue(v);
                        visited[v - 'A'] = true;
                    }
                }
            }
        }

        public void DFS(char startVertex, char endVertex)
        {
            bool[] visited = new bool[vertices];
            Stack<char> stack = new Stack<char>();

            stack.Push(startVertex);
            visited[startVertex - 'A'] = true;

            while (stack.Count > 0)
            {
                char currentVertex = stack.Pop();
                steps.Add(currentVertex);

                Console.WriteLine($"Popped: {currentVertex}");


                if (currentVertex == endVertex)
                {
                    Console.WriteLine("found");
                    dfsFlag = true;
                    break;
                }

                foreach (var edge in edges)
                {
                    char v = edge.Item1;
                    char w = edge.Item2;

                    if (v == currentVertex && !visited[w - 'A'])
                    {
                        stack.Push(w);
                        visited[w - 'A'] = true;
                    }
                    else if (w == currentVertex && !visited[v - 'A'])
                    {
                        stack.Push(v);
                        visited[v - 'A'] = true;
                    }
                }
            }
        }

        public void BranchAndBound(char startVertex, char endVertex)
        {
            PriorityQueue<Tuple<List<char>, int>> priorityQueue = new PriorityQueue<Tuple<List<char>, int>>((x, y) => x.Item2.CompareTo(y.Item2));
            HashSet<string> visitedStates = new HashSet<string>();

            priorityQueue.Enqueue(Tuple.Create(new List<char> { startVertex }, 0));

            while (priorityQueue.Count > 0)
            {
                var currentSolution = priorityQueue.Dequeue();
                char currentVertex = currentSolution.Item1.Last();
                steps.Add(currentVertex);

                if (currentVertex == endVertex)
                {
                    break;
                }

                foreach (var edge in edges)
                {
                    char v = edge.Item1;
                    char w = edge.Item2;
                    int weight = edge.Item3;

                    if (v == currentVertex && !currentSolution.Item1.Contains(w))
                    {
                        List<char> newPath = new List<char>(currentSolution.Item1) { w };
                        int newCost = currentSolution.Item2 + weight;

                        string newState = $"{w}{string.Join("", newPath.OrderBy(c => c))}";

                        if (!visitedStates.Contains(newState))
                        {
                            visitedStates.Add(newState);
                            priorityQueue.Enqueue(Tuple.Create(newPath, newCost));
                        }
                    }
                    else if (w == currentVertex && !currentSolution.Item1.Contains(v))
                    {
                        List<char> newPath = new List<char>(currentSolution.Item1) { v };
                        int newCost = currentSolution.Item2 + weight;

                        string newState = $"{v}{string.Join("", newPath.OrderBy(c => c))}";

                        if (!visitedStates.Contains(newState))
                        {
                            visitedStates.Add(newState);
                            priorityQueue.Enqueue(Tuple.Create(newPath, newCost));
                        }
                    }
                }
            }
        }

        public class PriorityQueue<T>
        {
            private List<T> elements;
            private readonly Comparison<T> comparison;

            public PriorityQueue(Comparison<T> comparison)
            {
                this.elements = new List<T>();
                this.comparison = comparison;
            }

            public void Enqueue(T item)
            {
                elements.Add(item);
                elements.Sort(comparison);
            }

            public T Dequeue()
            {
                if (elements.Count == 0)
                    throw new InvalidOperationException("Queue is empty");

                T item = elements[0];
                elements.RemoveAt(0);
                return item;
            }

            public int Count => elements.Count;
        }


    }
}
