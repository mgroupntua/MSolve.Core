using System;
using System.Collections.Generic;
using System.Text;
using MGroup.MSolve.Discretization.Interfaces;

//TODO: many of these operations would be more efficient if done simultaneously for free and constrained dofs.
namespace MGroup.MSolve.Discretization.FreedomDegrees
{
    public interface ISubdomainConstrainedDofOrdering
    {
        DofTable ConstrainedDofs { get; }
        int NumConstrainedDofs { get; }
        (int[] elementDofIndices, int[] subdomainDofIndices) MapConstrainedDofsElementToSubdomain(IElement element);
    }
}
