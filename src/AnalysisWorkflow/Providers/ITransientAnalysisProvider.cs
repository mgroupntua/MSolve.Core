using MGroup.MSolve.AnalysisWorkflow.Transient;
using MGroup.MSolve.Solution.LinearSystem;

//TODO: Perhaps the providers should not hold references to the linear systems. Instead they would return vectors/matrices to
//      the analyzers (or the vectors/matrices would be passed in and overwritten).
namespace MGroup.MSolve.AnalysisWorkflow.Providers
{
	public interface ITransientAnalysisProvider : IAnalyzerProvider
	{
		DifferentiationOrder ProblemOrder { get; }
		void SetTransientAnalysisPhase(TransientAnalysisPhase phase);
		IGlobalMatrix GetMatrix(DifferentiationOrder differentiationOrder);
		IGlobalVector GetRhs(double time);
		IGlobalVector GetVectorFromModelConditions(DifferentiationOrder differentiationOrder, double time);
	}
}
