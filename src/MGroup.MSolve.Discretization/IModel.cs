using System.Collections.Generic;
using MGroup.LinearAlgebra.Vectors;
using MGroup.MSolve.Discretization.Commons;
using MGroup.MSolve.Discretization.DofOrdering;

namespace MGroup.MSolve.Discretization
{
    public delegate Dictionary<int, SparseVector> NodalLoadsToSubdomainsDistributor(
        Table<INode, IDofType, double> globalNodalLoads);

    public interface IModel
    {
        Table<INode, IDofType, double> Constraints { get; }
        IReadOnlyList<IElement> Elements { get; }
        IGlobalFreeDofOrdering GlobalDofOrdering { get; set; } //TODO: this should not be managed by the model
        IList<IMassAccelerationHistoryLoad> MassAccelerationHistoryLoads { get; }
        IReadOnlyList<INode> Nodes { get; }
        IReadOnlyList<ISubdomain> Subdomains { get; }

        void AssignLoads(NodalLoadsToSubdomainsDistributor distributeNodalLoads); //TODOMaria: Here is where the element loads are assembled
        void AssignMassAccelerationHistoryLoads(int timeStep);
        void ConnectDataStructures();

        void AssignNodalLoads(NodalLoadsToSubdomainsDistributor distributeNodalLoads);
        void AssignTimeDependentNodalLoads(int timeStep, NodalLoadsToSubdomainsDistributor distributeNodalLoads);
    }
}
