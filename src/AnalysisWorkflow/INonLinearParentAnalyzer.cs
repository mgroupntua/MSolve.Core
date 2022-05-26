using MGroup.LinearAlgebra.Vectors;
using MGroup.MSolve.Solution.LinearSystem;

namespace MGroup.MSolve.AnalysisWorkflow
{
	public interface INonLinearParentAnalyzer : IParentAnalyzer
	{
		IGlobalVector GetOtherRhsComponents(IGlobalVector currentSolution);
	}
}
