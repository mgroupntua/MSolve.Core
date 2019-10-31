namespace MGroup.MSolve.Discretization
{
    public interface IMassAccelerationHistoryLoad
    {
        IDofType DOF { get; }
        double this[int currentTimeStep] { get; }
    }
}
