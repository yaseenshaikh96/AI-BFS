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

            newNode.connections.Add(new Connection(neighbourNode));
            neighbourNode.connections.Add(new Connection(newNode));
        }
        return newNode;
    }

    public void AddNode(Graph<T>.Node node)
    {
        if (nodes.Contains(node)) { Utility.PrintError("node already in graph"); return; }
        this.nodes.Add(node);
    }

    public Graph<T>.Node[] GetNodes() => nodes.ToArray();


    public void Connect(Node connector, params Connection[] connections)
    {
        foreach (Connection connection in connections)
        {
            Node neighbourNode = connection.node;
            if (connector == neighbourNode) { Utility.PrintError("node cannot connect to itself"); continue; }
            if (connector.IsConnected(neighbourNode)) { Utility.PrintError("connecting an already connected node"); continue; }
            if (!IsNodeInGraph(neighbourNode)) { Utility.PrintError("connecting node which is not in graph"); continue; }

            connector.connections.Add(new Connection(neighbourNode, connection.weight));
            neighbourNode.connections.Add(new Connection(connector, connection.weight));
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
        if (!nodes.Contains(nodeToDelete)) { Utility.PrintError("node to delete is not in graph"); return; }
        nodes.Remove(nodeToDelete);

        foreach (Connection neighbour in nodeToDelete.connections)
        {
            List<Connection> connectionList = neighbour.node.connections;
            for (int i = 0; i < connectionList.Count; i++)
            {
                if (connectionList[i].node == nodeToDelete)
                    connectionList.Remove(connectionList[i]);
            }
            neighbour.node.connections = connectionList;
        }

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
        public List<Connection> connections;
        public T? data;

        public Node(Graph<T> graph, string name, T? data = default(T))
        {
            this.name = name;
            this.connections = new List<Connection>();
            this.data = data;
            graph.AddNode(this);
        }

        public bool IsConnected(Node node)
        {
            foreach (Connection connection in connections)
            {
                if (connection.node == node)
                    return true;
            }
            return false;
        }
    }

    public class Connection
    {
        public Node node;
        public float weight;

        public Connection(Node neighbour, float weight = 1)
        {
            this.node = neighbour;
            this.weight = weight;
        }
    }
}