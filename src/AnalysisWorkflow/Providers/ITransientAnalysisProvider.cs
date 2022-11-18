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
		void LinearCombinationOfMatricesIntoEffectiveMatrix(TransientAnalysisCoefficients coefficients);
		void LinearCombinationOfMatricesIntoEffectiveMatrixNoOverwrite(TransientAnalysisCoefficients coefficients);
		IGlobalVector MatrixVectorProduct(DifferentiationOrder differentiationOrder, IGlobalVector vector);
		IGlobalVector GetVectorFromModelConditions(DifferentiationOrder differentiationOrder, double time);
		IGlobalVector GetRhs(double time);
		void ProcessRhs(TransientAnalysisCoefficients coefficients, IGlobalVector rhs);
		//IGlobalVector ZeroOrderDerivativeMatrixVectorProduct(IGlobalVector vector);
		//IGlobalVector FirstOrderDerivativeMatrixVectorProduct(IGlobalVector vector);
		//IGlobalVector SecondOrderDerivativeMatrixVectorProduct(IGlobalVector vector);
		//IGlobalVector GetFirstOrderDerivativeVectorFromBoundaryConditions(double time);
		//IGlobalVector GetSecondOrderDerivativeVectorFromBoundaryConditions(double time);
	}
}
