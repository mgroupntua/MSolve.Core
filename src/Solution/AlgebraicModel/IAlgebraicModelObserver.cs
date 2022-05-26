using System;
using System.Collections.Generic;
using System.Text;

namespace MGroup.MSolve.Solution.AlgebraicModel
{
	public interface IAlgebraicModelObserver
	{
		/// <summary>
		/// It will be called after the dof order is modified by calls to <see cref="IAlgebraicModel.OrderDofs"/>.
		/// </summary>
		void HandleDofOrderWasModified();
	}
}
