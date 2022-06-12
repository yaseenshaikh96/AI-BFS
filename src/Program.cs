public static class Program
{
    public static void Main(string[] args)
    {/*
        Graph<int> graph = new Graph<int>();
        Graph<int>.Node A = graph.CreateNode("A", 10);
        Graph<int>.Node B = graph.CreateNode("B", 20, new Graph<int>.Connection(A, 1));
        Graph<int>.Node C = graph.CreateNode("C", 30, new Graph<int>.Connection(A, 1), new Graph<int>.Connection(B, 2));
        Graph<int>.Node D = graph.CreateNode("D", 40, new Graph<int>.Connection(A, 1), new Graph<int>.Connection(C, 1));
        Graph<int>.Node E = graph.CreateNode("E", 50, new Graph<int>.Connection(C, 1), new Graph<int>.Connection(D, 1));

        graph.PrintGraph();*/

        Graph<(int, int)>.Node[]? path;
        Graph<(int, int)>? graph;

        graph = WaterJug.Solve(5, 3, 4);
        if (graph != null)
            graph.PrintGraph();

        /*if (path != null)
            foreach (var node in path)
            {
                System.Console.WriteLine("(" + node.data.Item1 + ", " + node.data.Item2 + ")");
            }*/
    }
}