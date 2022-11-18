using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.Entities;

namespace MGroup.MSolve.AnalysisWorkflow.Transient
{
	public interface INodalInitialCondition : INodalInitialCondition<IDofType>
	{

	}

	public interface INodalInitialCondition<out T> where T : IDofType
	{
		DifferentiationOrder DifferentiationOrder { get; }
		T DOF { get; }
		INode Node { get; }
		double Amount { get; }

		INodalInitialCondition<T> WithAmount(double amount);
	}
}
