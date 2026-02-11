using System.Numerics;

namespace ProblemSolving.Algorithms;

/// <summary>
/// 범용 플로이드-워셜 알고리즘
/// O(V^3)
/// </summary>
public class FloydWarshall
{
    public static T[,] Solve<T>(int n, T[,] graph, T infinity) where T : INumber<T>
    {
        var dist = (T[,])graph.Clone();

        for (var k = 0; k < n; k++)
        {
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (dist[i, k].Equals(infinity) || dist[k, j].Equals(infinity)) continue;

                    T combinedDist = dist[i, k] + dist[k, j];

                    // 기존 거리보다 k를 거쳐가는 거리가 더 짧으면 갱신
                    if (combinedDist < dist[i, j]) dist[i, j] = combinedDist;
                }
            }
        }

        return dist;
    }
}
