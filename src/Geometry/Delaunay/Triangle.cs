namespace MGroup.MSolve.Core.Geometry.Delaunay
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class Triangle
	{
		internal int hash;

		internal int id;

		internal Otri[] neighbors;

		internal Vertex[] vertices;

		internal Osub[] subsegs;

		internal int label;

		internal double area;

		internal bool infected;

		public Triangle()
		{
			vertices = new Vertex[3];
			subsegs = new Osub[3];
			neighbors = new Otri[3];
		}
	}
}
