using System;
using System.Collections.Generic;
using System.Text;
using MGroup.MSolve.Discretization.FreedomDegrees;
using MGroup.MSolve.Discretization.Interfaces;

namespace MGroup.MSolve.Discretization.Loads
{
	public class Load
	{
		public INode Node { get; set; }
		public IDofType DOF { get; set; }
		public double Amount { get; set; }
	}
}
