using SearchAlgo;
public class Program
{
    private static void Main(string[] args)
    {
        var graph = new Search('Z');
        graph.AddEdge('A', 'B', 5);
        graph.AddEdge('A', 'C', 3);
        graph.AddEdge('A', 'D', 1);
        graph.AddEdge('B', 'E', 1);
        graph.AddEdge('C', 'F', 1);
        graph.AddEdge('E', 'F', 1);
        graph.AddEdge('D', 'F', 1);
        

        //Console.WriteLine("Breadth First Traversal starting from vertex 2:");
        //graph.BFS('A', 'C');
        graph.DFS('A', 'E');
        //graph.BranchAndBound('A', 'F');
        Console.WriteLine("\n\n steps:\n");
        foreach(int n in graph.steps)
        {
            Console.WriteLine(n);
        }
    }
}