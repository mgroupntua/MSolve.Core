using System.Collections.Generic;
using MGroup.LinearAlgebra.Matrices;
using MGroup.LinearAlgebra.Vectors;
using MGroup.MSolve.Discretization;
using MGroup.MSolve.Solution.LinearSystem;

//TODO: This should be called second order provider. The matrices, coefficients, etc. should be named 0th-order, 1st-order,
//      2nd-order.
//TODO: Implicit/explicit time integration logic should be defined by the analyzer and implemented by the provider, in order to
//      reuse the analyzer for problems that have a slightly different differential equation (e.g. coupled problems).
//TODO: Perhaps the providers should not hold references to the linear systems. Instead they would return vectors/matrices to
//      the analyzers (or the vectors/matrices would be passed in and overwritten).
//TODO: Rename the Get~ methods to Calculate or something similar.
namespace MGroup.MSolve.AnalysisWorkflow.Providers
{
	public interface ITransientAnalysisProvider : IAnalyzerProvider
	{
		void ProcessRhs(TransientAnalysisCoefficients coefficients, IGlobalVector rhs);
		//TODO: This should not exist at all. The provider should return the 0th order (stiffness), 1st order (damping) and 2nd
		//      order matrices (or some matrix representations that can be combined between them and multiplied with vectors).
		void LinearCombinationOfMatricesIntoEffectiveMatrix(TransientAnalysisCoefficients coefficients);
		IGlobalVector FirstOrderDerivativeMatrixVectorProduct(IGlobalVector vector);
		IGlobalVector SecondOrderDerivativeMatrixVectorProduct(IGlobalVector vector);
		IGlobalVector GetFirstOrderDerivativeVectorFromBoundaryConditions(double time);
		IGlobalVector GetSecondOrderDerivativeVectorFromBoundaryConditions(double time);
		IGlobalVector GetRhs(double time);
	}
}
