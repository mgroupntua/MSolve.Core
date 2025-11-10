namespace MGroup.MSolve.AnalysisWorkflow
{
	using MGroup.LinearAlgebra.Vectors;

	public interface INonLinearParentAnalyzer : IParentAnalyzer
	{
		IVector GetOtherRhsComponents(IVector currentSolution);
	}
}
