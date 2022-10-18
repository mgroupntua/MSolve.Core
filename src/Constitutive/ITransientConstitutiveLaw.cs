namespace MGroup.MSolve.Constitutive
{
	/// <summary>
	/// Interface for constitutive laws to be adhered to, for spatial discretization (e.g.: FEM) 
	/// </summary>
	public interface ITransientConstitutiveLaw : IConstitutiveLaw
	{
		void SetCurrentTime(double time);
	}

	public static class TransientLiterals
	{
		public const string TIME = "time";
	}
}
