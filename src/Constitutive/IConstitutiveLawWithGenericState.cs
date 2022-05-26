using MGroup.MSolve.DataStructures;

namespace MGroup.MSolve.Constitutive
{
	/// <summary>
	/// Interface for constitutive laws to be adhered to, for spatial discretization (e.g.: FEM) that uses the GenericConstitutiveLawState object for holding its state
	/// </summary>
	public interface IConstitutiveLawWithGenericState : IConstitutiveLaw
	{
		GenericConstitutiveLawState CurrentState { get; set; }
		new GenericConstitutiveLawState CreateState();
		bool ICreateState.IsCurrentStateDifferent(IHaveState state) => state == null || state.Equals(CurrentState) == false;
	}
}
