using System;
using System.Collections.Generic;
using System.Linq;
using MGroup.LinearAlgebra.Matrices;
using MGroup.MSolve.Discretization.BoundaryConditions;
using MGroup.MSolve.Discretization.Dofs;
using MGroup.MSolve.Discretization.Entities;

namespace MGroup.MSolve.Discretization
{
    public enum ElementDimensions
    {
        Unknown = 0,
        OneD = 1,
        TwoD = 2,
        ThreeD = 3
    }
     
    public interface IElementType
    {
        int ID { get; set; }
        IReadOnlyList<INode> Nodes { get; }
        int SubdomainID { get; set; }
        CellType CellType { get; }
        IElementDofEnumerator DofEnumerator { get; set; }
        IReadOnlyList<IReadOnlyList<IDofType>> GetElementDofTypes();
        void SaveConstitutiveLawState();
        Tuple<double[], double[]> CalculateResponse(double[] localDisplacements);
        double[] CalculateResponseIntegral();
        double[] CalculateResponseIntegralForLogging(double[] localDisplacements);
        IMatrix PhysicsMatrix();

		public bool MapNodalBoundaryConditionsToElementVector(IEnumerable<INodalBoundaryCondition<IDofType>> nodalBoundaryConditions, double[] elementVector)
		{
			//TODO: It would be more convenient to have a DofTable per element, instead of IReadOnlyList<IReadOnlyList<IDofType>>
			var constraints = nodalBoundaryConditions
				.Where(x => x.Amount != 0d)
				.GroupBy(x => x.Node.ID)
				.ToDictionary(x => x.Key, x => x.Select(x => (x.DOF, x.Amount)));
			IReadOnlyList<INode> nodes = this.DofEnumerator.GetNodesForMatrixAssembly(this);
			IReadOnlyList<IReadOnlyList<IDofType>> dofs = this.DofEnumerator.GetDofTypesForMatrixAssembly(this);
			if (nodes.Any(x => constraints.ContainsKey(x.ID)) == false)
			{
				return false;
			}

			int dofIdxOffset = 0;
			for (int n = 0; n < nodes.Count; ++n)
			{
				INode node = nodes[n];
				if (constraints.ContainsKey(node.ID))
				{
					// Associate dofs with their indices into the element vector
					var dofIndices = new Dictionary<IDofType, int>();
					for (int d = 0; d < dofs[n].Count; ++d)
					{
						dofIndices[dofs[n][d]] = dofIdxOffset + d;
					}

					// Add the contributions from prescribed dirichlet conditions
					foreach (var constraint in constraints[node.ID])
					{
						int idx = dofIndices[constraint.DOF];
						elementVector[idx] += constraint.Amount;
					}
				}

				dofIdxOffset += dofs[n].Count;
			}

			return true;
		}

		public IDictionary<(INode Node, IDofType DOF), double> MapElementVectorToNodalValues(double[] elementVector)
		{
			var nodalValues = new Dictionary<(INode, IDofType), double>();

			IReadOnlyList<INode> nodes = this.DofEnumerator.GetNodesForMatrixAssembly(this);
			IReadOnlyList<IReadOnlyList<IDofType>> dofs = this.DofEnumerator.GetDofTypesForMatrixAssembly(this);
			int idx = 0;
			for (int n = 0; n < nodes.Count; n++)
			{
				INode node = nodes[n];
				// Associate dofs with their indices into the element vector
				for (int d = 0; d < dofs[n].Count; d++)
				{
					if (elementVector[idx] != 0)
					{
						nodalValues.Add((node, dofs[n][d]), elementVector[idx]);
					}
					idx++;
				}
			}

			return nodalValues;
		}
	}
}
