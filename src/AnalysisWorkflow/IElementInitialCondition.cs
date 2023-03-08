using MGroup.MSolve.Discretization;
using MGroup.MSolve.Discretization.Dofs;

namespace MGroup.MSolve.AnalysisWorkflow.Transient
{
	public interface IElementInitialCondition<out T> : IElementModelQuantity<T> where T : IDofType
	{
		DifferentiationOrder DifferentiationOrder { get; }

		IElementInitialCondition<T> WithMultiplier(double multiplier);
	}
}
