using System.Collections.Generic;
using System.Linq;

using MGroup.MSolve.DataStructures;
using MGroup.MSolve.Solution.LinearSystem;

namespace MGroup.MSolve.AnalysisWorkflow
{
	/// <summary>
	/// A generic state object for constitutive law state variables
	/// </summary>
	public class GenericAnalyzerState : IHaveState
	{
		private readonly IAnalyzer analyzer;
		private readonly Dictionary<string, IGlobalVector> stateVectors;
		private readonly Dictionary<string, double> stateValues;

		public IReadOnlyDictionary<string, double> StateValues => stateValues;
		public IReadOnlyDictionary<string, IGlobalVector> StateVectors => stateVectors;

		public GenericAnalyzerState(IAnalyzer analyzer, IList<(string Name, IGlobalVector Value)> stateVectors, IList<(string Name, double Value)> stateValues)
		{
			this.analyzer = analyzer;
			this.stateValues = stateValues.ToDictionary(x => x.Name, x => x.Value);
			this.stateVectors = stateVectors.ToDictionary(x => x.Name, x => x.Value);
		}

		public GenericAnalyzerState(IAnalyzer analyzer, IList<(string Name, IGlobalVector Value)> stateVectors)
			: this(analyzer, stateVectors, new[] { (string.Empty, 0d) })
		{
		}

		public GenericAnalyzerState(IAnalyzer newAnalyzer, GenericAnalyzerState state)
		{
			this.analyzer = newAnalyzer;
			this.stateValues = state.stateValues;
			this.stateVectors = state.stateVectors;
		}

		public void RestoreState() => analyzer.CurrentState = this;

		public override bool Equals(object obj)
		{
			if (obj == null || (obj is GenericAnalyzerState) == false)
			{
				return false;
			}

			GenericAnalyzerState other = (GenericAnalyzerState)obj;
			bool stateValuesEqual = (other.stateValues ?? new Dictionary<string, double>())
				.OrderBy(kvp => kvp.Key)
				.SequenceEqual((this.stateValues ?? new Dictionary<string, double>())
					.OrderBy(kvp => kvp.Key));
			if (stateValuesEqual == false)
			{
				return false;
			}

			return (other.stateVectors ?? new Dictionary<string, IGlobalVector>())
				.OrderBy(kvp => kvp.Key)
				.SequenceEqual((this.stateVectors ?? new Dictionary<string, IGlobalVector>())
					.OrderBy(kvp => kvp.Key));
		}

		public override int GetHashCode() => stateValues.GetHashCode();
	}
}
