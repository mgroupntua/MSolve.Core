using System;
using System.Collections.Generic;
using MGroup.LinearAlgebra.Matrices;
using MGroup.MSolve.Solvers.DomainDecomposition.Dual.StiffnessDistribution;
using MGroup.MSolve.Solvers.DomainDecomposition.Dual.LagrangeMultipliers;
using MGroup.MSolve.Solvers.DomainDecomposition.Dual.Pcg;
using MGroup.MSolve.Discretization.Interfaces;

//TODO: Also add ReorderInternalDofsForMultiplication and ReorderBoundaryDofsForMultiplication
namespace MGroup.MSolve.Solvers.DomainDecomposition.Dual.Preconditioning
{
    public interface IFetiPreconditionerFactory
    {
        bool ReorderInternalDofsForFactorization { get; }

        IFetiPreconditioner CreatePreconditioner(IModel model, IStiffnessDistribution stiffnessDistribution,
            IDofSeparator dofSeparator, ILagrangeMultipliersEnumerator lagrangeEnumerator, 
            Dictionary<int, IFetiSubdomainMatrixManager> matrixManagers);
    }
}
