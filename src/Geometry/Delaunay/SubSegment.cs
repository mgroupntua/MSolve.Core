namespace MGroup.MSolve.Core.Geometry.Delaunay
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	internal class SubSegment
	{
		internal int hash;

		internal Osub[] subsegs;

		internal Vertex[] vertices;

		internal Otri[] triangles;

		internal int boundary;

		public SubSegment()
		{
			vertices = new Vertex[4];
			boundary = 0;
			subsegs = new Osub[2];
			triangles = new Otri[2];
		}
	}
}
