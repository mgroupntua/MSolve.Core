namespace MGroup.MSolve.Core.Geometry.Delaunay
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	internal enum VertexType
	{
		InputVertex,
		SegmentVertex,
		FreeVertex,
		DeadVertex,
		UndeadVertex
	}
}
