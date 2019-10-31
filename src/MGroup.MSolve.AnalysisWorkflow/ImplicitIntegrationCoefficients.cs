namespace MGroup.MSolve.AnalysisWorkflow
{
	public class ImplicitIntegrationCoefficients
	{
		public double Mass { get; set; } = double.NaN;
		public double Damping { get; set; } = double.NaN;
		public double Stiffness { get; set; } = double.NaN;
	}
}
