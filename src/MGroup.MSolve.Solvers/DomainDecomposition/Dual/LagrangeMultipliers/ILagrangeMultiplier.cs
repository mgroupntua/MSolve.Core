using MGroup.MSolve.Discretization.FreedomDegrees;
using MGroup.MSolve.Discretization.Interfaces;

namespace MGroup.MSolve.Solvers.DomainDecomposition.Dual.LagrangeMultipliers
{
	public interface ILagrangeMultiplier
	{
//TODO: perhaps I should also store the dof indices in each subdomain. In that case, creating the boolean matrices can be 
//      decoupled from the lagrange enumeration.
		IDofType DofType { get; }
		INode Node { get; }
		ISubdomain SubdomainMinus { get; }
		ISubdomain SubdomainPlus { get; }
	}
}

