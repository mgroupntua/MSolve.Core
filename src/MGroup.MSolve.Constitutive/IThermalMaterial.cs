namespace MGroup.MSolve.Constitutive
{
	/// <summary>
	/// Contains material properties used for thermal conductivity problems. These are uniform for the whole element and immutable.
	/// Authors: Serafeim Bakalakos
	/// </summary>
	public interface IThermalMaterial
	{
		double Density { get; }
		double SpecialHeatCoeff { get; }
		double ThermalConductivity { get; }
	}
}
