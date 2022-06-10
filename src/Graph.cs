public class Graph
{
    public List<Node> nodes { get; private set; }

    public Graph()
    {
        this.nodes = new List<Node>();
    }

    public Node AddNode(string NodeName, params Node[] neighbourNodes)
    {
        Node newNode = new Node(NodeName, this);
        nodes.Add(newNode);

        foreach (Node neighbourNode in neighbourNodes)
        {
            if (!IsNodeInGraph(neighbourNode)) continue;
            newNode.neighbours.Add(neighbourNode);
            neighbourNode.neighbours.Add(newNode);
        }
        return newNode;
    }

    public void Connect(Node connector, params Node[] neighbourNodes)
    {
        if (connector.parentGraph != this) return;
        foreach (Node neighbourNode in neighbourNodes)
        {
            if (neighbourNode.parentGraph != this) continue;
            if (connector.neighbours.Contains(neighbourNode)) continue;
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
        {
            neighbour.neighbours.Remove(nodeToDelete);
        }
    }
    //---------------------------------------------------//

    public class Node
    {
        public string name;
        public List<Node> neighbours;
        public Graph parentGraph;

        public Node(string name, Graph parentGraph)
        {
            this.name = name;
            this.neighbours = new List<Node>();
            this.parentGraph = parentGraph;
        }
    }
}