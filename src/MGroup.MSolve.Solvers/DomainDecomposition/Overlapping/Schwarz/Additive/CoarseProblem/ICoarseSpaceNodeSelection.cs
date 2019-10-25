namespace MGroup.MSolve.Solvers.DomainDecomposition.Overlapping.Schwarz.Additive.CoarseProblem
{
    public interface ICoarseSpaceNodeSelection
    {
        int[] GetConstrainedCoarseSpaceDofs();

        int[] GetFreeCoarseSpaceDofs();
    }
}