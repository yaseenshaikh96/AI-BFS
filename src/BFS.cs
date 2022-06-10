public class BFS
{
    public Graph graph { get; private set; }

    public BFS(Graph graph)
    {
        this.graph = graph;
    }

    public string Traverse()
    {
        string output = "";
        Queue<Graph.Node> queue = new Queue<Graph.Node>();
        List<Graph.Node> visited = new List<Graph.Node>();

        queue.Enqueue(graph.nodes[0]);
        visited.Add(graph.nodes[0]);

        while (queue.Count != 0)
        {
            Graph.Node currentNode = queue.Dequeue();
            output += currentNode.name;

            for (int i = 0; i < currentNode.neighbours.Count; i++)
            {

                Graph.Node currentNeighbour = currentNode.neighbours[i];

                if (!visited.Contains(currentNeighbour))
                {
                    queue.Enqueue(currentNeighbour);
                    visited.Add(currentNeighbour);
                }
            }
        }

        return output;
    }
}
