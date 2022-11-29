using MGroup.MSolve.AnalysisWorkflow.Transient;
using MGroup.MSolve.Solution.LinearSystem;

//TODO: Perhaps the providers should not hold references to the linear systems. Instead they would return vectors/matrices to
//      the analyzers (or the vectors/matrices would be passed in and overwritten).
//TODO: Rename the Get~ methods to Calculate or something similar.
namespace MGroup.MSolve.AnalysisWorkflow.Providers
{
	public interface ITransientAnalysisProvider : IAnalyzerProvider
	{
		//TODO: This should not exist at all. The provider should return the 0th order (stiffness), 1st order (damping) and 2nd
		//      order matrices (or some matrix representations that can be combined between them and multiplied with vectors).
		//void LinearCombinationOfMatricesIntoEffectiveMatrix(TransientAnalysisCoefficients coefficients);
		//void LinearCombinationOfMatricesIntoEffectiveMatrixNoOverwrite(TransientAnalysisCoefficients coefficients);
		//void ProcessRhs(TransientAnalysisCoefficients coefficients, IGlobalVector rhs);
		//IGlobalVector MatrixVectorProduct(DifferentiationOrder differentiationOrder, IGlobalVector vector);
		DifferentiationOrder ProblemOrder { get; }
		IGlobalMatrix GetMatrix(DifferentiationOrder differentiationOrder);
		IGlobalVector GetRhs(double time);
		IGlobalVector GetVectorFromModelConditions(DifferentiationOrder differentiationOrder, double time);
	}
}
