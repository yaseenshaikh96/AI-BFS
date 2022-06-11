public class Graph<T>
{
    private List<Node> nodes;

    public Graph()
    {
        this.nodes = new List<Node>();
    }

    public Node CreateNode(string NodeName, T? data = default(T), params Node[] neighbourNodes)
    {
        Node newNode = new Node(this, NodeName, data);

        foreach (Node neighbourNode in neighbourNodes)
        {
            if (!IsNodeInGraph(neighbourNode)) { Utility.PrintError("connecting node which is not in graph"); continue; }

            newNode.neighbours.Add(neighbourNode);
            neighbourNode.neighbours.Add(newNode);
        }
        return newNode;
    }

    public void AddNode(Graph<T>.Node node)
    {
        if (nodes.Contains(node)) { Utility.PrintError("node already in graph"); return; }
        this.nodes.Add(node);
    }

    public Graph<T>.Node[] GetNodes() => nodes.ToArray();


    public void Connect(Node connector, params Node[] neighbourNodes)
    {
        foreach (Node neighbourNode in neighbourNodes)
        {
            if (connector == neighbourNode) { Utility.PrintError("node cannot connect to itself"); continue; }
            if (connector.neighbours.Contains(neighbourNode)) { Utility.PrintError("connecting an already connected node"); continue; }
            if (!IsNodeInGraph(neighbourNode)) { Utility.PrintError("connecting node which is not in graph"); continue; }

            connector.neighbours.Add(neighbourNode);
            neighbourNode.neighbours.Add(connector);
        }
    }

    public bool IsNodeInGraph(Node node)
    {
        foreach (Node nodeInList in nodes)
            if (node == nodeInList)
                return true;
        return false;
    }

    public void DeleteNode(Node nodeToDelete)
    {
        if (!nodes.Contains(nodeToDelete)) return;
        nodes.Remove(nodeToDelete);

        foreach (Node neighbour in nodeToDelete.neighbours)
            neighbour.neighbours.Remove(nodeToDelete);

        if (IsGraphFragmented()) Utility.PrintError("graph got fragmented");
    }

    public bool IsGraphFragmented()
    {
        Node[] visited = BFS.Traverse<T>(this);
        return visited.Length != nodes.ToArray().Length;
    }

    //---------------------------------------------------//

    public class Node
    {
        public string name;
        public List<Node> neighbours;
        public T? data;

        public Node(Graph<T> graph, string name, T? data = default(T))
        {
            this.name = name;
            this.neighbours = new List<Node>();
            this.data = data;
            graph.AddNode(this);
        }
    }
}