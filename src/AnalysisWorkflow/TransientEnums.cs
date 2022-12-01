namespace MGroup.MSolve.AnalysisWorkflow.Transient
{
	public enum DifferentiationOrder
	{
		Zero = 0,
		First,
		Second,
		Third,
	}

	public enum TransientAnalysisPhase
	{
		SteadyStateSolution = 0,
		InitialConditionEvaluation,
		Solution,
	}
}
