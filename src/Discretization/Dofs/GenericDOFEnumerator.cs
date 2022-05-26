using System.Collections.Generic;
using MGroup.LinearAlgebra.Matrices;
using MGroup.MSolve.Discretization.Entities;

namespace MGroup.MSolve.Discretization.Dofs
{
	public class GenericDofEnumerator : IElementDofEnumerator
	{
		public IReadOnlyList<IReadOnlyList<IDofType>> GetDofTypesForMatrixAssembly(IElementType element) 
            => element.GetElementDofTypes();

        public IReadOnlyList<IReadOnlyList<IDofType>> GetDofTypesForDofEnumeration(IElementType element) 
            => element.GetElementDofTypes();

        public IReadOnlyList<INode> GetNodesForMatrixAssembly(IElementType element) => element.Nodes;

        public IMatrix GetTransformedMatrix(IMatrix matrix) => matrix;

        public double[] GetTransformedDisplacementsVector(double[] vector) => vector;

        public double[] GetTransformedForcesVector(double[] vector) => vector;
    }
}
