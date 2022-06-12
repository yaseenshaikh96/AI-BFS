public static class WaterJug
{
    //Graph<(int, int)>.Node[]?
    public static Graph<(int, int)>? Solve(int jug1Cap, int jug2Cap, int target)
    {
        int cycleCount = 0;
        Graph<(int, int)> graph = new Graph<(int, int)>();
        Graph<(int, int)>.Node initial = new Graph<(int, int)>.Node(graph, "initial", (0, 0));

        Queue<Graph<(int, int)>.Node> queue = new Queue<Graph<(int, int)>.Node>();
        List<Graph<(int, int)>.Node> visited = new List<Graph<(int, int)>.Node>();


        queue.Enqueue(initial);

        while (queue.Count != 0)
        {
            cycleCount++;
            if (cycleCount > 100)
            {
                graph.PrintGraph();
                return null;
            }

            Graph<(int, int)>.Node current = queue.Dequeue();

            bool isCurrentVisited = false;
            foreach (var node in visited)
                if (node.IsDataEqual(current))
                {
                    isCurrentVisited = true;
                    break;
                }

            if (isCurrentVisited) continue;

            if (current.data.Item1 > jug1Cap
                || current.data.Item2 > jug2Cap
                || current.data.Item1 < 0
                || current.data.Item2 < 0)
                continue;

            visited.Add(current);

            if (current.data.Item1 == target)
            {
                graph.CreateNode("final jug1", (current.data.Item1, 0), new Graph<(int, int)>.Connection(current, 1));
                visited.Add(new Graph<(int, int)>.Node(graph, "final jug1", (current.data.Item1, 0)));
                return graph;//visited.ToArray();
            }
            if (current.data.Item2 == target)
            {
                graph.CreateNode("final jug2", (0, current.data.Item2), new Graph<(int, int)>.Connection(current, 1));
                visited.Add(new Graph<(int, int)>.Node(graph, "final jug2", (0, current.data.Item2)));
                return graph;//visited.ToArray();
            }

            Graph<(int, int)>.Node[] newStates = new Graph<(int, int)>.Node[6];
            newStates[0] = new Graph<(int, int)>.Node(graph, "fill jug1", (jug1Cap, current.data.Item2));
            newStates[1] = new Graph<(int, int)>.Node(graph, "fill jug2", (current.data.Item1, jug2Cap));
            newStates[2] = new Graph<(int, int)>.Node(graph, "empth jug1", (0, current.data.Item2));
            newStates[3] = new Graph<(int, int)>.Node(graph, "empty jug2", (current.data.Item1, 0));

            queue.Enqueue(newStates[0]);
            queue.Enqueue(newStates[1]);
            queue.Enqueue(newStates[2]);
            queue.Enqueue(newStates[3]);


            for (int pourAmount = 0; pourAmount <= MathF.Max(jug1Cap, jug2Cap); pourAmount++)
            {
                int waterInJug1 = current.data.Item1 + pourAmount;
                int waterInJug2 = current.data.Item2 - pourAmount;

                if ((waterInJug1 == jug1Cap && waterInJug2 >= 0) || waterInJug2 == 0)
                {
                    newStates[4] = new Graph<(int, int)>.Node(graph, "jug2 to jug1", (waterInJug1, waterInJug2));
                    queue.Enqueue(newStates[4]);
                }
                waterInJug1 = current.data.Item1 - pourAmount;
                waterInJug2 = current.data.Item2 + pourAmount;

                if ((waterInJug2 == jug2Cap && waterInJug1 >= 0) || waterInJug1 == 0)
                {
                    newStates[5] = new Graph<(int, int)>.Node(graph, "jug1 to jug2", (waterInJug1, waterInJug2));
                    queue.Enqueue(newStates[5]);
                }
            }


            foreach (Graph<(int, int)>.Node newState in newStates)
                graph.Connect(current, new Graph<(int, int)>.Connection(newState, 1));

        }
        System.Console.Write("Steps: " + cycleCount);
        return null;
    }
}
/*
q.Add(new Tuple<int, int>(u.Item1, b));
         
        // Fill Jug1
        q.Add(new Tuple<int, int>(a, u.Item2));
  
        for(int ap = 0; ap <= Math.Max(a, b); ap++)
        {
             
            // Pour amount ap from Jug2 to Jug1
            int c = u.Item1 + ap;
            int d = u.Item2 - ap;
  
            // Check if this state is possible or not
            if (c == a || (d == 0 && d >= 0))
                q.Add(new Tuple<int, int>(c, d));
  
            // Pour amount ap from Jug 1 to Jug2
            c = u.Item1 - ap;
            d = u.Item2 + ap;
  
            // Check if this state is possible or not
            if ((c == 0 && c >= 0) || d == b)
                q.Add(new Tuple<int, int>(c, d));
        }
         
        // Empty Jug2
        q.Add(new Tuple<int, int>(a, 0));
         
        // Empty Jug1
        q.Add(new Tuple<int, int>(0, b));
*/