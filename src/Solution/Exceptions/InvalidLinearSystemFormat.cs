using System;
using System.Collections.Generic;
using System.Text;

namespace MGroup.MSolve.Solution.Exceptions
{
	public class InvalidLinearSystemFormat : ArgumentException
	{
		public InvalidLinearSystemFormat()
		{
		}

		public InvalidLinearSystemFormat(string message)
			: base(message)
		{
		}

		public InvalidLinearSystemFormat(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
