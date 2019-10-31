using MGroup.MSolve.Discretization.FreedomDegrees;

namespace MGroup.MSolve.Discretization
{
    public interface IMassAccelerationHistoryLoad
    {
        IDofType DOF { get; }
        double this[int currentTimeStep] { get; }
    }
}
