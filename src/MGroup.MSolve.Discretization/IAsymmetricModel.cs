using System.Collections.Generic;
using MGroup.MSolve.Discretization.FreedomDegrees;

namespace MGroup.MSolve.Discretization
{
	public interface IAsymmetricModel : IModel
	{
		IGlobalFreeDofOrdering GlobalRowDofOrdering { get; set; }
		IGlobalFreeDofOrdering GlobalColDofOrdering { get; set; }

		IReadOnlyList<IAsymmetricSubdomain> Subdomains { get; }
	}
}
