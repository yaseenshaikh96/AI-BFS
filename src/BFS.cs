public static class BFS
{
    public static Graph<V>.Node[] Traverse<V>(Graph<V> graph)
    {
        Queue<Graph<V>.Node> queue = new Queue<Graph<V>.Node>();
        List<Graph<V>.Node> visited = new List<Graph<V>.Node>();

        queue.Enqueue(graph.nodes[0]);
        visited.Add(graph.nodes[0]);

        while (queue.Count != 0)
        {
            Graph<V>.Node currentNode = queue.Dequeue();

            for (int i = 0; i < currentNode.neighbours.Count; i++)
            {
                Graph<V>.Node currentNeighbour = currentNode.neighbours[i];

                if (visited.Contains(currentNeighbour)) continue;
                queue.Enqueue(currentNeighbour);
                visited.Add(currentNeighbour);

            }
        }
        return visited.ToArray();
    }
}
