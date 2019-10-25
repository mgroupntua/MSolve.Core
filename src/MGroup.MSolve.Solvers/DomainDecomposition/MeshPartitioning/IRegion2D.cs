using MGroup.MSolve.Discretization.Interfaces;

namespace MGroup.MSolve.Solvers.DomainDecomposition.MeshPartitioning
{
    public enum NodePosition
    {
        Internal, Boundary, External
    }

    public interface IRegion2D
    {
        NodePosition FindRelativePosition(INode node);
    }
}
