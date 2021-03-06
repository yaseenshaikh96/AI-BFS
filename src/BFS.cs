public static class BFS
{
    public static Graph<V>.Node[] Traverse<V>(Graph<V> graph)
    {
        Queue<Graph<V>.Node> queue = new Queue<Graph<V>.Node>();
        List<Graph<V>.Node> visited = new List<Graph<V>.Node>();

        Graph<V>.Node first = graph.GetNodes()[0];

        queue.Enqueue(first);
        visited.Add(first);

        while (queue.Count != 0)
        {
            Graph<V>.Node currentNode = queue.Dequeue();

            for (int i = 0; i < currentNode.connections.Count; i++)
            {
                Graph<V>.Node currentNeighbour = currentNode.connections[i].node;

                if (visited.Contains(currentNeighbour)) continue;
                queue.Enqueue(currentNeighbour);
                visited.Add(currentNeighbour);

            }
        }
        return visited.ToArray();
    }
}
