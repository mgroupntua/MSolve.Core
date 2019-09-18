using MGroup.MSolve.Discretization.FreedomDegrees;

namespace MGroup.MSolve.Discretization.Interfaces
{
	public interface IAsymmetricSubdomain:ISubdomain
	{
		ISubdomainFreeDofOrdering FreeDofRowOrdering { get; set; }
		ISubdomainFreeDofOrdering FreeDofColOrdering { get; set; }

        ISubdomainConstrainedDofOrdering ConstrainedDofRowOrdering { get; set; }
        ISubdomainConstrainedDofOrdering ConstrainedDofColOrdering { get; set; }
    }
}