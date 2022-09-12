namespace MGroup.MSolve.AnalysisWorkflow
{
	public interface IStepwiseAnalyzer : IParentAnalyzer
	{
		int Steps { get; }
		int CurrentStep { get; }
		new void Solve();
		void AdvanceStep();
	}
}
