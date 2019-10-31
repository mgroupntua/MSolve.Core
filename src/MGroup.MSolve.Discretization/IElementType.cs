using System;
using System.Collections.Generic;
using MGroup.LinearAlgebra.Matrices;
using MGroup.MSolve.Discretization.Loads;
using MGroup.MSolve.Discretization.Mesh;

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
        CellType CellType { get; }
        IElementDofEnumerator DofEnumerator { get; set; }
        IMatrix StiffnessMatrix(IElement element);
        IMatrix MassMatrix(IElement element);
        IMatrix DampingMatrix(IElement element);

        bool MaterialModified { get; }
        void ResetMaterialModified();
        Tuple<double[], double[]> CalculateStresses(IElement element, double[] localDisplacements, double[] localdDisplacements);
        double[] CalculateForces(IElement element, double[] localDisplacements, double[] localdDisplacements);
        double[] CalculateForcesForLogging(IElement element, double[] localDisplacements);
        double[] CalculateAccelerationForces(IElement element, IList<MassAccelerationLoad> loads);
        void SaveMaterialState();
        void ClearMaterialState();

        void ClearMaterialStresses();
		IReadOnlyList<IReadOnlyList<IDofType>> GetElementDofTypes(IElement element);
    }
}
