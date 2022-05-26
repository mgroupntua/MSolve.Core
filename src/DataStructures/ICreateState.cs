namespace MGroup.MSolve.DataStructures
{
	public interface ICreateState
	{
		IHaveState CreateState();
		bool IsCurrentStateDifferent(IHaveState state);
	}
}
