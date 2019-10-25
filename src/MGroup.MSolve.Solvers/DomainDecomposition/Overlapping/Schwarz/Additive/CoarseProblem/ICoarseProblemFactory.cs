using System.Collections.Generic;
using MGroup.LinearAlgebra.Matrices;
using MGroup.MSolve.Solvers.DomainDecomposition.Overlapping.Schwarz.Additive.Interfaces;

namespace MGroup.MSolve.Solvers.DomainDecomposition.Overlapping.Schwarz.Additive.CoarseProblem
{
    public interface ICoarseProblemFactory
    {
        void GenerateMatrices(IMatrixView matrix,IModelOverlappingDecomposition modelOverlappingDecomposition);
        Matrix RetrievePreconditionerContribution();
    }
}
