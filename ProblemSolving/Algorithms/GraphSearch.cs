namespace ProblemSolving.Algorithms;

public class GraphSearch
{
    public static void BFS<T>(
        T startNode,
        Func<T, IEnumerable<T>> getNeighbors,
        Action<T> visitAction)
    {
        var visited = new HashSet<T>();
        var queue = new Queue<T>();

        visited.Add(startNode);
        queue.Enqueue(startNode);

        while (queue.Count > 0)
        {
            T curr = queue.Dequeue();
            visitAction(curr); // Perform work on the node

            foreach (var neighbor in getNeighbors(curr))
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }

    public static void DFSRecursive<T>(
        T curr,
        Func<T, IEnumerable<T>> getNeighbors,
        HashSet<T> visited,
        Action<T> visitAction)
    {
        if (visited.Contains(curr)) return;

        visited.Add(curr);
        visitAction(curr);

        foreach (var neighbor in getNeighbors(curr))
        {
            DFSRecursive(neighbor, getNeighbors, visited, visitAction);
        }
    }

    public static void DFSIterative<T>(
        T startNode,
        Func<T, IEnumerable<T>> getNeighbors,
        Action<T> visitAction)
    {
        var visited = new HashSet<T>();
        var stack = new Stack<T>();

        stack.Push(startNode);

        while (stack.Count > 0)
        {
            T curr = stack.Pop();

            if (!visited.Contains(curr))
            {
                visited.Add(curr);
                visitAction(curr);

                foreach (var neighbor in getNeighbors(curr))
                {
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
                }
            }
        }
    }
}
