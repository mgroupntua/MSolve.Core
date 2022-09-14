using System;
using System.Collections.Generic;
using System.Text;
using MGroup.LinearAlgebra.Matrices;

//TODO: This belongs in LinearAlgebra project
namespace MGroup.MSolve.Solution.LinearSystem
{
	public interface IGlobalMatrix : ILinearTransformation
	{
		public bool CheckForCompatibility { get; set; }

		IGlobalMatrix Add(IGlobalMatrix otherMatrix) => Axpy(otherMatrix, +1.0);

		void AddIntoThis(IGlobalMatrix otherMatrix) => AxpyIntoThis(otherMatrix, +1.0);

		IGlobalMatrix Axpy(IGlobalMatrix otherMatrix, double otherCoefficient)
		{
			IGlobalMatrix result = Copy();
			result.AxpyIntoThis(otherMatrix, otherCoefficient);
			return result;
		}

		void AxpyIntoThis(IGlobalMatrix otherMatrix, double otherCoefficient)
			=> LinearCombinationIntoThis(+1.0, otherMatrix, otherCoefficient);

		void Clear();

		//TODO: It would be better if this and the matrices in LinearAlgebra exposed CreateZeroWithSamePattern() and CopyFrom().
		IGlobalMatrix Copy();

		public IGlobalMatrix LinearCombination(double thisCoefficient, IGlobalMatrix otherMatrix, double otherCoefficient)
		{
			IGlobalMatrix result = Copy();
			result.LinearCombinationIntoThis(thisCoefficient, otherMatrix, otherCoefficient);
			return result;
		}

		void LinearCombinationIntoThis(double thisCoefficient, IGlobalMatrix otherMatrix, double otherCoefficient);

		IGlobalMatrix Scale(double coefficient)
		{
			IGlobalMatrix result = Copy();
			result.ScaleIntoThis(coefficient);
			return result;
		}

		void ScaleIntoThis(double coefficient);

		IGlobalMatrix Subtract(IGlobalMatrix otherMatrix) => Axpy(otherMatrix, -1.0);

		void SubtractIntoThis(IGlobalMatrix otherMatrix) => AxpyIntoThis(otherMatrix, -1.0);
	}
}
