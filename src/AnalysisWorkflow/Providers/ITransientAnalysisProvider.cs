//TODO: Perhaps the providers should not hold references to the linear systems. Instead they would return vectors/matrices to
//      the analyzers (or the vectors/matrices would be passed in and overwritten).
namespace MGroup.MSolve.AnalysisWorkflow.Providers
{
	using MGroup.LinearAlgebra.Matrices;
	using MGroup.LinearAlgebra.Vectors;
	using MGroup.MSolve.AnalysisWorkflow.Transient;

	public interface ITransientAnalysisProvider : IAnalyzerProvider
	{
		DifferentiationOrder ProblemOrder { get; }
		void SetTransientAnalysisPhase(TransientAnalysisPhase phase);
		IMatrix GetMatrix(DifferentiationOrder differentiationOrder);
		IVector GetRhs(double time);
		IVector GetVectorFromModelConditions(DifferentiationOrder differentiationOrder, double time);
	}
}
