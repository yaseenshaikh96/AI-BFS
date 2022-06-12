public static class Program
{
    public static void Main(string[] args)
    {
        /*        Graph<int> graph = new Graph<int>();
                Graph<int>.Node A = graph.CreateNode("A", 0);
                Graph<int>.Node B = graph.CreateNode("B", 1);
                Graph<int>.Node C = graph.CreateNode("C", 2);
                Graph<int>.Node D = graph.CreateNode("D", 3);
                Graph<int>.Node E = graph.CreateNode("E", 4);

                graph.Connect(A, new Graph<int>.Connection(B, 2));
                graph.Connect(B, new Graph<int>.Connection(C, 3));
                graph.Connect(C, new Graph<int>.Connection(D, 4));
                graph.Connect(D, new Graph<int>.Connection(E, 5));

                Graph<int>.Node[] nodes = BFS.Traverse(graph);
                foreach (var node in nodes)
                {
                    System.Console.Write("Name: " + node.name + ", ");
                    System.Console.Write("Data: " + node.data + ", ");
                    foreach (Graph<int>.Connection connection in node.connections)
                    {
                        System.Console.Write("weight: " + connection.weight + ", For: " + connection.node.name + ", ");
                    }
                    System.Console.Write("\n");
                }
        */
        Graph<int> graph = new Graph<int>();
        Graph<int>.Node A = graph.CreateNode("A", 10);
        Graph<int>.Node B = graph.CreateNode("B", 20, new Graph<int>.Connection(A, 1));
        Graph<int>.Node C = graph.CreateNode("C", 30, new Graph<int>.Connection(A, 1), new Graph<int>.Connection(B, 2));
        Graph<int>.Node D = graph.CreateNode("D", 40, new Graph<int>.Connection(A, 1), new Graph<int>.Connection(C, 1));
        Graph<int>.Node E = graph.CreateNode("E", 50, new Graph<int>.Connection(C, 1), new Graph<int>.Connection(D, 1));

        graph.PrintGraph();
    }
}