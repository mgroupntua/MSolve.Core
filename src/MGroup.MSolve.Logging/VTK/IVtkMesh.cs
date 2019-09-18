using System.Collections.Generic;

namespace MGroup.MSolve.Logging.VTK
{
    public interface IVtkMesh
    {
        IReadOnlyList<VtkCell> VtkCells { get; }
        IReadOnlyList<VtkPoint> VtkPoints { get; }
    }
}
