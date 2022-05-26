using System;
using System.Collections.Generic;
using System.Text;
using MGroup.MSolve.Discretization;

//TODO: Perhaps these should be done by a component other than IAlgebraicModel. We are taking advantage of the fact that 
//		IAlgebraicModel knows about the domain decomposition and parallelization. However, IAlgebraicModel is designed to 
//		facilitate the transformation of data between physical model and linear algebra entities, not take care of all
//		parallelization needs. Furthermore IAlgebraicModel implementations are gradually becoming god classes.
//TODO: Func<int, IEnumerable<IElement>> accessElements is cumbersome and so far only used to access all the elements of the
//		model. The exact same result can be done by letting algebraic model go over all elements, without specifying, how to 
//		access them. However, these accessor callbacks can be useful for models with more than one lists of elements and  
//		especially with generic TElement: IElement.
namespace MGroup.MSolve.Solution.AlgebraicModel
{
	public interface IElementIterator
	{
		/// <summary>
		/// Performs <paramref name="elementOperation"/> on all elements/>.
		/// </summary>
		/// <param name="elementOperation"></param>
		void DoPerElement<TElement>(Action<TElement> elementOperation) 
			where TElement: IElementType;

		/// <summary>
		/// Performs <paramref name="elementOperation"/> on all elements accessed by calling <paramref name="accessElements"/>.
		/// The resulting element vectors are reduced into a single result with <paramref name="numReducedValues"/> entries. 
		/// </summary>
		/// <param name="numReducedValues"></param>
		/// <param name="accessElements"></param>
		/// <param name="elementOperation"></param>
		/// <returns></returns>
		double[] ReduceSumPerElement<TElement>(int numReducedValues, Func<int, IEnumerable<TElement>> accessElements, 
			Func<TElement, double[]> elementOperation)
			where TElement: IElementType;

		/// <summary>
		/// Performs <paramref name="elementOperation"/> on all elements accessed by calling <paramref name="accessElements"/>,
		/// which also satisfy <paramref name="isActiveElement"/>.
		/// The resulting element vectors are reduced into a single result with <paramref name="numReducedValues"/> entries. 
		/// </summary>
		/// <param name="numReducedValues"></param>
		/// <param name="accessElements"></param>
		/// <param name="isActiveElement"></param>
		/// <param name="elementOperation"></param>
		/// <returns></returns>
		double[] ReduceSumPerElement<TElement>(int numReducedValues, Func<int, IEnumerable<TElement>> accessElements,
			Predicate<TElement> isActiveElement, Func<TElement, double[]> elementOperation)
			where TElement: IElementType;
	}
}
