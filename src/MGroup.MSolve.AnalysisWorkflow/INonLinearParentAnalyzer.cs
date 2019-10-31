using MGroup.LinearAlgebra.Vectors;
using MGroup.MSolve.Solution.LinearSystems;

namespace MGroup.MSolve.AnalysisWorkflow
{
	//TODO: Confusing name. The child analyzer of this is a nonlinear analyzer.
	public interface INonLinearParentAnalyzer : IParentAnalyzer
	{
		IVector GetOtherRhsComponents(ILinearSystem linearSystem, IVector currentSolution);
	}
}
