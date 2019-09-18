using MGroup.LinearAlgebra.Matrices;
using MGroup.MSolve.Discretization.Interfaces;

//TODO: Should this be in the Problems project?
namespace MGroup.MSolve.Discretization.Providers
{
    public class ElementStructuralMassProvider : IElementMatrixProvider
    {
        public IMatrix Matrix(IElement element) => element.ElementType.MassMatrix(element);
    }
}
