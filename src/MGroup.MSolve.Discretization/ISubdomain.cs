using System.Collections.Generic;
using MGroup.LinearAlgebra.Vectors;
using MGroup.MSolve.Discretization.Commons;
using MGroup.MSolve.Discretization.DofOrdering;

//TODO: tidy up the methods that concern material state
namespace MGroup.MSolve.Discretization
{
    public interface ISubdomain
    {
        Table<INode, IDofType, double> Constraints { get; }

        ISubdomainConstrainedDofOrdering ConstrainedDofOrdering { get; set; }

        /// <summary>
        /// This should be set when the analyzer decides. E.g. an XFEM or adaptive FEM analyzer would need to create a new dof 
        /// ordering, whenever the crack propagates or the mesh is refined respectively.
        /// </summary>
        ISubdomainFreeDofOrdering FreeDofOrdering { get; set; }

        IReadOnlyList<IElement> Elements { get; } //TODO: perhaps this should be a set

        Vector Forces { get; set; } //TODO: this should be a Vector or IVector and stored elsewhere.

        int ID { get; }

        bool ConnectivityModified { get; set; }
        bool StiffnessModified { get; set; }

        IReadOnlyList<INode> Nodes { get; } //TODO: perhaps this should be a set

        double[] CalculateElementIncrementalConstraintDisplacements(IElement element, double constraintScalingFactor); //TODO: this should be done by a dedicated class instead of the subdomain

        double[] CalculateElementDisplacements(IElement element, IVectorView globalDisplacementVector);

        void ClearMaterialStresses();

        IVector GetRHSFromSolutionWithInitialDisplacementsEffect(IVectorView solution, IVectorView dSolution,
	        Dictionary<int, INode> boundaryNodes,
	        Dictionary<int, Dictionary<IDofType, double>> initialConvergedBoundaryDisplacements,
	        Dictionary<int, Dictionary<IDofType, double>> totalBoundaryDisplacements,
	        int nIncrement, int totalIncrements);


		IVector GetRhsFromSolution(IVectorView solution, IVectorView dSolution); //TODO: this should be done by a dedicated class instead of the subdomain

        void ResetMaterialsModifiedProperty();

        void ScaleConstraints(double scalingFactor); //TODO: this should be done by a dedicated class instead of the subdomain

        void SaveMaterialState();

		void SaveIncrementalContraints();

	}
}
