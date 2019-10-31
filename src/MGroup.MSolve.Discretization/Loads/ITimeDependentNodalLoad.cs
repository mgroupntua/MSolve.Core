namespace MGroup.MSolve.Discretization.Loads
{
	public interface ITimeDependentNodalLoad
	{
		INode Node { get; set; }
		IDofType DOF { get; set; }

		double GetLoadAmount(int timeStep);
	}
}
