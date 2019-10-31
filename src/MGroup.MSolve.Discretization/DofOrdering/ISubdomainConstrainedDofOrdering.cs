//TODO: many of these operations would be more efficient if done simultaneously for free and constrained dofs.
namespace MGroup.MSolve.Discretization.DofOrdering
{
    public interface ISubdomainConstrainedDofOrdering
    {
        DofTable ConstrainedDofs { get; }
        int NumConstrainedDofs { get; }
        (int[] elementDofIndices, int[] subdomainDofIndices) MapConstrainedDofsElementToSubdomain(IElement element);
    }
}
