using System;
using System.Collections.Generic;
using MGroup.MSolve.Solution.LinearSystem;

//TODO: perhaps the solver should expose the assembler, instead of wrapping it. The assembler's interface would have to be 
//      simplified a bit though. That would violate LoD, but so does MSolve in general.
namespace MGroup.MSolve.Solution
{
	/// <summary>
	/// Helps translate the physical model into a linear system and then solves the latter. 
	/// </summary>
	public interface ISolver : ILinearSystemObserver
	{
		IGlobalLinearSystem LinearSystem { get; }

		/// <summary>
		/// Logs information, such as linear system size, the time required for various solver tasks, etc.
		/// </summary>
		ISolverLogger Logger { get; }

		/// <summary>
		/// The name of the solver for logging purposes.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Initializes the state of this <see cref="ISolver"/> instance. This needs to be called only once, since it  
		/// could potentially perform actions that must not be repeated or are too expensive.
		/// </summary>
		void Initialize();
		
		/// <summary>
		/// Notifies this <see cref="ISolver"/> that it cannot overwrite the data of <see cref="IGlobalLinearSystem.Matrix"/>.
		/// Some solvers would otherwise overwrite the matrices (e.g. with the factorization) to avoid using extra memory.
		/// </summary>
		void PreventFromOverwrittingSystemMatrices();

		/// <summary>
		/// Solves the linear systems.
		/// </summary>
		void Solve();
	}
}
