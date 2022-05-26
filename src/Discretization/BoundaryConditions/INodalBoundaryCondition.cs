using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.Entities;

namespace MGroup.MSolve.Discretization.BoundaryConditions
{
	public interface INodalBoundaryCondition : INodalBoundaryCondition<IDofType>
	{

	}

	public interface INodalBoundaryCondition<out T> where T : IDofType
	{
		T DOF { get; }

		INode Node { get; }

		double Amount { get; }
		INodalBoundaryCondition<T> WithAmount(double amount);

	}
}
