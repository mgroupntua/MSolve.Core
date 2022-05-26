namespace MGroup.MSolve.AnalysisWorkflow
{
	public class TransientAnalysisCoefficients
	{
		public double SecondOrderDerivativeCoefficient { get; set; } = double.NaN;
		public double FirstOrderDerivativeCoefficient { get; set; } = double.NaN;
		public double ZeroOrderDerivativeCoefficient { get; set; } = double.NaN;
	}
}
