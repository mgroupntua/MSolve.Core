using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.AnalysisWorkflow.Transient
{
	public interface IDomainInitialCondition<out T> where T : IDofType
	{
		DifferentiationOrder DifferentiationOrder { get; }
		T DOF { get; }

		double Amount { get; }
		IDomainInitialCondition<T> WithAmount(double amount);
	}
}
