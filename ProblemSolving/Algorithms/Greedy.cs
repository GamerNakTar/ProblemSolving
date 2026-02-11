namespace ProblemSolving.Algorithms;

/// <summary>
/// 범용 그리디 알고리즘
/// </summary>
public class Greedy
{
    public static TSolution Solve<TCandidate, TSolution>(
        IEnumerable<TCandidate> candidates,
        Func<TSolution, TCandidate, bool> isFeasible,
        Func<TSolution, TCandidate, TSolution> updateSolution,
        TSolution initialSolution)
    {
        TSolution currentSolution = initialSolution;

        foreach (var candidate in candidates)
        {
            if (isFeasible(currentSolution, candidate))
            {
                currentSolution = updateSolution(currentSolution, candidate);
            }
        }

        return currentSolution;
    }
}
