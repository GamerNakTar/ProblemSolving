using ProblemSolving.Algorithms;

namespace ProblemSolving;

internal static class Program
{
    static void Main()
    {
        var N = int.Parse(Console.ReadLine());
        var map = new int[N, N];
        var visited = new bool[N, N];
        int[] dx = { 0, 0, 1, -1 };
        int[] dy = { 1, -1, 0, 0 };

        for (var i = 0; i < N; i++)
        {
            var line = Console.ReadLine();
            for (var j = 0; j < N; j++)
            {
                map[i, j] = line[j] - '0';
            }
        }

        var complexCounts = new List<int>();

        for (var i = 0; i < N; i++)
        {
            for (var j = 0; j < N; j++)
            {
                if (map[i, j] == 1 && !visited[i, j])
                {
                    complexCounts.Add(Bfs(i, j));
                }
            }
        }

        complexCounts.Sort();
        Console.WriteLine(complexCounts.Count);
        foreach (var count in complexCounts)
        {
            Console.WriteLine(count);
        }

        return;

        int Bfs(int x, int y)
        {
            var queue = new Queue<(int, int)>();
            queue.Enqueue((x, y));
            visited[x, y] = true;
            var count = 0;

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                count++;

                for (var i = 0; i < 4; i++)
                {
                    var nx = curr.Item1 + dx[i];
                    var ny = curr.Item2 + dy[i];

                    if (nx < 0 || nx >= N || ny < 0 || ny >= N) continue;
                    if (map[nx, ny] != 1 || visited[nx, ny]) continue;

                    visited[nx, ny] = true;
                    queue.Enqueue((nx, ny));
                }
            }

            return count;
        }
    }
}
