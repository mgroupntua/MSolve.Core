using System.Collections.Generic;
using System.Linq;
using MGroup.MSolve.DataStructures;

namespace MGroup.MSolve.Constitutive
{
	/// <summary>
	/// A generic state object for constitutive law state variables
	/// </summary>
	public class GenericConstitutiveLawState : IHaveStateWithValues
	{
		private readonly IConstitutiveLawWithGenericState constitutiveLaw;
		private readonly Dictionary<string, double> stateValues;

		public IReadOnlyDictionary<string, double> StateValues => stateValues;

		public GenericConstitutiveLawState(IConstitutiveLawWithGenericState constitutiveLaw, IList<(string Name, double Value)> stateValues)
		{
			this.constitutiveLaw = constitutiveLaw;
			this.stateValues = stateValues.ToDictionary(x => x.Name, x => x.Value);
		}

		public void RestoreState() => constitutiveLaw.CurrentState = this;

		public override bool Equals(object obj)
		{
			if (obj == null || (obj is GenericConstitutiveLawState) == false)
			{
				return false;
			}

			GenericConstitutiveLawState other = (GenericConstitutiveLawState)obj;
			return (other.stateValues ?? new Dictionary<string, double>())
				.OrderBy(kvp => kvp.Key)
				.SequenceEqual((this.stateValues ?? new Dictionary<string, double>())
					.OrderBy(kvp => kvp.Key));
		}

		public override int GetHashCode() => stateValues.GetHashCode();
	}
}
