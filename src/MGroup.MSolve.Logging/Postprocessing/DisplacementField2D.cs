using System.Collections.Generic;
using MGroup.LinearAlgebra.Vectors;
using MGroup.MSolve.Discretization.FreedomDegrees;
using MGroup.MSolve.Discretization.Interfaces;

namespace MGroup.MSolve.Logging.Postprocessing
{
    /// <summary>
    /// Recovers the nodal displacements from the solution of an analysis step. For now it only works for linear analysis.
    /// Authors: Serafeim Bakalakos
    /// </summary>
    public class DisplacementField2D
    {
        private readonly Dictionary<INode, double[]> data;
        private readonly IModel model;

        public DisplacementField2D(IModel model)
        {
            this.model = model;
            this.data = new Dictionary<INode, double[]>(model.Nodes.Count);
        }

        public void FindNodalDisplacements(IVectorView solution)
        {
            foreach (var node in model.Nodes)
            {
                //if (nodalDofs.Count != 2) throw new Exception("There must be exactly 2 dofs per node, X and Y");
                bool isFree = model.GlobalDofOrdering.GlobalFreeDofs.TryGetValue(node, StructuralDof.TranslationX, out int dofXIdx);
                double ux = isFree ? solution[dofXIdx] : 0.0;
                isFree = model.GlobalDofOrdering.GlobalFreeDofs.TryGetValue(node, StructuralDof.TranslationY, out int dofYIdx);
                double uy = isFree ? solution[dofYIdx] : 0.0;
                data.Add(node, new double[] { ux, uy });
            }
        }

        public double[] this[INode node] => data[node];
    }
}
