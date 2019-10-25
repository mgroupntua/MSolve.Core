using MGroup.LinearAlgebra.Matrices;

namespace MGroup.MSolve.Solvers.DomainDecomposition.Overlapping.Schwarz.Additive.Interfaces
{
    public interface IModelOverlappingDecomposition
    {
        int NumberOfSubdomains { get; }
        void DecomposeMatrix();
        int[] GetConnectivityOfSubdomain(int indexSubdomain);
        IMatrix CoarseSpaceInterpolation { get; }
    }
}
