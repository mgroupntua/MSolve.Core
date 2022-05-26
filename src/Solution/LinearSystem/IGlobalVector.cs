using System;
using System.Collections.Generic;
using System.Text;

//TODO: Eventually this should be joined with IVector and be in MGroup.LinearAlgebra project
namespace MGroup.MSolve.Solution.LinearSystem
{
	public interface IGlobalVector
	{
		IGlobalVector Add(IGlobalVector otherVector) => Axpy(otherVector, +1.0);

		void AddIntoThis(IGlobalVector otherVector) => AxpyIntoThis(otherVector, +1.0);

		IGlobalVector Axpy(IGlobalVector otherVector, double otherCoefficient)
			{
			IGlobalVector result = Copy();
			result.AxpyIntoThis(otherVector, otherCoefficient);
			return result;
		}

		void AxpyIntoThis(IGlobalVector otherVector, double otherCoefficient)
			=> LinearCombinationIntoThis(+1.0, otherVector, otherCoefficient);

		void Clear();

		IGlobalVector Copy()
		{
			IGlobalVector copy = CreateZero();
			copy.CopyFrom(this);
			return copy;
		}

		void CopyFrom(IGlobalVector other);

		IGlobalVector CreateZero();

		double DotProduct(IGlobalVector otherVector);

		IGlobalVector LinearCombination(double thisCoefficient, IGlobalVector otherVector, double otherCoefficient) //TODO: This (and similar default methods) should be an extension method
		{
			IGlobalVector result = Copy();
			result.LinearCombinationIntoThis(thisCoefficient, otherVector, otherCoefficient);
			return result;
		}

		int Length();

		void LinearCombinationIntoThis(double thisCoefficient, IGlobalVector otherVector, double otherCoefficient);

		double Norm2() => Math.Sqrt(this.DotProduct(this));

		IGlobalVector Scale(double coefficient)
		{
			IGlobalVector result = Copy();
			result.ScaleIntoThis(coefficient);
			return result;
		}

		void ScaleIntoThis(double coefficient);

		void SetAll(double value);

		IGlobalVector Subtract(IGlobalVector otherVector) => Axpy(otherVector, -1.0);

		void SubtractIntoThis(IGlobalVector otherVector) => AxpyIntoThis(otherVector, -1.0);
	}
}
