using MGroup.MSolve.DataStructures;
using MGroup.MSolve.Solution.LinearSystem;

namespace MGroup.MSolve.AnalysisWorkflow
{
	public interface INonLinearModelUpdater
	{
		void UpdateState(IHaveState externalState);

		IGlobalVector CalculateResponseIntegralVector(IGlobalVector solution);

	}
}
