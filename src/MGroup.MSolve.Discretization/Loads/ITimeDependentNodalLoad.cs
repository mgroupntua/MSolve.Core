using System;
using System.Collections.Generic;
using System.Text;
using MGroup.MSolve.Discretization.FreedomDegrees;
using MGroup.MSolve.Discretization.Interfaces;

namespace MGroup.MSolve.Discretization.Loads
{
	public interface ITimeDependentNodalLoad
	{
		INode Node { get; set; }
		IDofType DOF { get; set; }

		double GetLoadAmount(int timeStep);
	}
}
