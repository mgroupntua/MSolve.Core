using MGroup.LinearAlgebra.Vectors;

namespace MGroup.MSolve.Discretization.Loads
{
	public interface IDirichletEquivalentLoadsAssembler
	{
		IVector GetEquivalentNodalLoads(ISubdomain subdomain, IVectorView solution, double constraintScalingFactor);
	}
}
