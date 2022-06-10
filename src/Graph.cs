public class Graph
{
    public List<Node> nodes { get; private set; }

    public Graph()
    {
        this.nodes = new List<Node>();
    }

    public Node AddNode(string NodeName, params Node[] neighbourNodes)
    {
        Node newNode = new Node(NodeName);
        nodes.Add(newNode);

        foreach (Node neighbourNode in neighbourNodes)
        {
            if (!IsNodeInGraph(neighbourNode))
            {
                Utility.PrintError("connecting node which is not in graph");
                continue;
            }
            newNode.neighbours.Add(neighbourNode);
            neighbourNode.neighbours.Add(newNode);
        }
        return newNode;
    }

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
        BFS bfs = new BFS(this);
        Node[] visited = bfs.Traverse();

        return visited.Length != nodes.ToArray().Length;
    }

    //---------------------------------------------------//

    public class Node
    {
        public string name;
        public List<Node> neighbours;

        public Node(string name)
        {
            this.name = name;
            this.neighbours = new List<Node>();
        }
    }
}