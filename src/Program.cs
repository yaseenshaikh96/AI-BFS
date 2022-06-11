public static class Program
{
    public static void Main(string[] args)
    {
        Graph<int> graph = new Graph<int>();
        Graph<int>.Node A = graph.CreateNode("A", 0);
        Graph<int>.Node B = graph.CreateNode("B", 1, A);
        Graph<int>.Node C = graph.CreateNode("C", 2, B);
        Graph<int>.Node D = graph.CreateNode("D", 3, C);
        Graph<int>.Node E = graph.CreateNode("E", 4, D);

        Graph<int>.Node[] nodes = BFS.Traverse(graph);
        foreach (var node in nodes)
            System.Console.WriteLine(node.data);


    }
}