using System;
using System.Linq;

namespace MGroup.MSolve.AnalysisWorkflow.Transient
{
	public enum DifferentiationOrder
	{
		Zero = 0,
		First,
		Second,
		Third,
	}

	//public class TransientAnalysisCoefficients
	//{
	//	private double[] coefficients = Enumerable.Repeat(0d, Enum.GetNames(typeof(DifferentiationOrder)).Length).ToArray();
	//	public double this[DifferentiationOrder o] { get => coefficients[(int)o]; set => coefficients[(int)o] = value; }
	//}
}
