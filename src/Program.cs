public static class Program
{
    public static void Main(string[] args)
    {
        Graph<int> graph = new Graph<int>();

        Graph<int>.Node A = graph.AddNode("A", 0);
        Graph<int>.Node B = graph.AddNode("B", 1, A);
        Graph<int>.Node C = graph.AddNode("C", 2, A);
        Graph<int>.Node D = graph.AddNode("D", 3, A);
        Graph<int>.Node E = graph.AddNode("E", 4, A);
        Graph<int>.Node F = graph.AddNode("F", 5, A);
        Graph<int>.Node G = graph.AddNode("G", 6, A);

        Graph<int>.Node[] nodes = BFS.Traverse<int>(graph);

        Graph<string> grapsString = new Graph<string>();
        Graph<String>.Node aa = grapsString.AddNode("stringA", null);
        Graph<String>.Node ab = grapsString.AddNode("stringA", null, aa);
        Graph<String>.Node ac = grapsString.AddNode("stringA", null, ab);
        Graph<String>.Node ad = grapsString.AddNode("stringA", null, ac);
        Graph<String>.Node ae = grapsString.AddNode("stringA", null, ad);
        Graph<String>.Node af = grapsString.AddNode("stringA", null, ae);

        Graph<string>.Node[] nodesString = BFS.Traverse<string>(grapsString);

        foreach (Graph<int>.Node node in nodes)
            System.Console.WriteLine(node.data);

        foreach (Graph<string>.Node node in nodesString)
            System.Console.WriteLine(node.data);
    }
}