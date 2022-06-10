public static class Program
{
    public static void Main(string[] args)
    {
        Graph graph = new Graph();
        Graph.Node A = graph.AddNode("A");
        Graph.Node B = graph.AddNode("B", A);
        Graph.Node C = graph.AddNode("C", B);

        graph.DeleteNode(A);
    }
}