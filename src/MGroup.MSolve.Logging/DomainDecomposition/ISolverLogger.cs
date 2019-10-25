using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

//TODO: Use enums instead of strings for the solver task and dof category. Or use interfaces & enum classes, to adhere to 
//      open-closed principle.
namespace MGroup.MSolve.Logging.DomainDecomposition
{
	public interface ISolverLogger
	{
		int GetNumDofs(int analysisStep, string category);

		int GetNumIterationsOfIterativeAlgorithm(int analysisStep);
		double GetResidualNormRatioOfIterativeAlgorithm(int analysisStep);

		/// <summary>
		/// Adds the duration of the selected task to the duration of the same task during the current analysis step.
		/// </summary>
		/// <param name="task"></param>
		/// <param name="duration"></param>
		void LogTaskDuration(string task, long duration);
		void LogNumDofs(string category, int numDofs);
		void LogIterativeAlgorithm(int iterations, double residualNormRatio);

		/// <summary>
		/// Each iteration is defined by the solution phase of ISolver. Dof ordering and matrix assembly may also be included, 
		/// but they are not necessarily repeated in all analyses. Thus call it at the end of the Solve() method.
		/// </summary>
		void IncrementAnalysisStep();
		void WriteToFile(string path, string title, bool append);
		void WriteAggregatesToFile(string path, string title, bool append);
	}
}
