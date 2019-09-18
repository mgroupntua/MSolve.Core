using MGroup.LinearAlgebra.Matrices;

namespace MGroup.MSolve.Discretization.Interfaces
{
	public interface IPorousElement:IElementType
	{
		IMatrix PermeabilityMatrix(IElement element);
		IMatrix CouplingMatrix(IElement element);
		IMatrix SaturationMatrix(IElement element);
	}
}