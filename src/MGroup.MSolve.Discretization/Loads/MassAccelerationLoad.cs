using System;
using System.Collections.Generic;
using System.Text;
using MGroup.MSolve.Discretization.FreedomDegrees;

namespace MGroup.MSolve.Discretization.Loads
{
	public class MassAccelerationLoad
	{
		public IDofType DOF { get; set; }
		public double Amount { get; set; }
	}
}
