using MGroup.MSolve.Solution.LinearSystem;

namespace MGroup.MSolve.AnalysisWorkflow
{
	public interface INonLinearModelUpdater
	{
		void UpdateState();

		IGlobalVector CalculateResponseIntegralVector(IGlobalVector solution);
	}
}
