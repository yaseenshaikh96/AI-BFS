public class Graph<T>
{
    private List<Node> nodes;

    public Graph()
    {
        this.nodes = new List<Node>();
    }

    public Node CreateNode(string NodeName, T? data = default(T), params Connection[] connections)
    {
        Node newNode = new Node(this, NodeName, data);
        Connect(newNode, connections);
        return newNode;
    }

    public Graph<T>.Node[] GetNodes() => nodes.ToArray();

    public void Connect(Node connector, params Connection[] connections)
    {
        if (!nodes.Contains(connector)) { Utility.PrintError("Node to connect not in graph"); return; }
        foreach (Connection connection in connections)
        {
            Node neighbourNode = connection.node;
            if (connector == neighbourNode) { Utility.PrintError("node cannot connect to itself"); continue; }
            if (connector.IsConnected(neighbourNode)) { Utility.PrintError("connecting an already connected node"); continue; }
            if (!nodes.Contains(neighbourNode)) { Utility.PrintError("connecting node which is not in graph"); continue; }

            connector.connections.Add(new Connection(neighbourNode, connection.weight));
            neighbourNode.connections.Add(new Connection(connector, connection.weight));
        }
    }

    public void Connect(Node node1, Node node2, float weight)
    {
        if (!nodes.Contains(node1) || !nodes.Contains(node2)) { Utility.PrintError("connecting node which is not in graph"); return; }
        if (!node1.IsConnected(node1))
            node1.connections.Add(new Connection(node2, weight));
        if (!node2.IsConnected(node1))
            node2.connections.Add(new Connection(node1, weight));
    }

    public bool IsNodeInGraph(Node node)
    {
        return nodes.Contains(node);
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

    public void PrintGraph()
    {
        System.Console.Write($"# of nodes: {nodes.Count}\n");
        foreach (var node in nodes)
        {
            System.Console.Write("Name: " + node.name + ", ");
            System.Console.Write("Data: " + node.data + ", ");
            foreach (Graph<T>.Connection connection in node.connections)
                System.Console.Write("weight: " + connection.weight + ", For: " + connection.node.name + ", ");

            System.Console.Write("\n");
        }
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
            graph.nodes.Add(this);
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
        public bool IsDataEqual(Node node2)
        {
            return EqualityComparer<T>.Default.Equals(this.data, node2.data);
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