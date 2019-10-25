using MGroup.MSolve.Discretization.FreedomDegrees;
using MGroup.MSolve.Discretization.Interfaces;

namespace MGroup.MSolve.Solvers.Ordering
{
	public interface IAsymmetricDofOrderingStrategy
	{
		(int numGlobalFreeDofs, DofTable globalFreeDofs) OrderGlobalDofs(IAsymmetricModel model);

		(int numSubdomainFreeDofs, DofTable subdomainFreeDofs) OrderSubdomainDofs(IAsymmetricSubdomain subdomain);
	}
}
