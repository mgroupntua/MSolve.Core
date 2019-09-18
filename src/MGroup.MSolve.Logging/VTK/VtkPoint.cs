using MGroup.MSolve.Discretization.Interfaces;
using MGroup.MSolve.Geometry.Coordinates;

namespace MGroup.MSolve.Logging.VTK
{
    /// <summary>
    /// Vertex used to represent VTK grids.
    /// Authors: Serafeim Bakalakos
    /// </summary>
    public class VtkPoint: CartesianPoint
    {
        public VtkPoint(int id, double x, double y, double z) : base(x, y, z)
        {
            this.ID = id;
        }

        public VtkPoint(int id, INode node) : base(node.X, node.Y, node.Z)
        {
            this.ID = id;
        }

        public int ID { get; }
    }
}
