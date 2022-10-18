namespace MGroup.MSolve.DataStructures
{
	using System.Collections.Generic;

	public interface IHaveStateWithValues : IHaveState
	{
		IReadOnlyDictionary<string, double> StateValues { get; }
	}
}
