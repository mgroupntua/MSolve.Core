using MGroup.MSolve.Geometry.Coordinates;

namespace MGroup.MSolve.Discretization.Mesh
{
    public interface IDomain2DBoundary
    {
        // Not on the boundary exactly.
        bool IsInside(CartesianPoint point);
    }
}
