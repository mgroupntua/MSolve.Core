namespace MGroup.MSolve.Core.Geometry.Delaunay
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class Mesh
	{
		internal Behavior behavior;
		internal Rectangle bounds;
		internal SubSegment dummysub;
		internal Triangle dummytri;
		internal int hash_vtx;
		internal List<Point> holes;
		internal int hullsize;
		internal int invertices;
		internal int mesh_dim;
		internal int steinerleft;
		internal Dictionary<int, SubSegment> subsegs;
		internal TrianglePool triangles;
		internal int undeads;
		internal Dictionary<int, Vertex> vertices;

		private Stack<Otri> flipstack;
		private IPredicates predicates;

		internal Mesh(Configuration config)
		{
			Initialize();
			behavior = new Behavior();
			vertices = new Dictionary<int, Vertex>();
			subsegs = new Dictionary<int, SubSegment>();
			triangles = config.TrianglePool();
			flipstack = new Stack<Otri>();
			holes = new List<Point>();
			steinerleft = -1;
			predicates = config.Predicates();
		}

		internal IEnumerable<Triangle> Triangles => triangles;

		internal void MakeTriangle(ref Otri newotri)
		{
			Triangle triangle = triangles.Get();
			triangle.subsegs[0].seg = dummysub;
			triangle.subsegs[1].seg = dummysub;
			triangle.subsegs[2].seg = dummysub;
			triangle.neighbors[0].tri = dummytri;
			triangle.neighbors[1].tri = dummytri;
			triangle.neighbors[2].tri = dummytri;
			newotri.tri = triangle;
			newotri.orient = 0;
		}

		internal void TransferNodes(IList<Vertex> points)
		{
			invertices = points.Count;
			mesh_dim = 2;
			bounds = new Rectangle();
			if (invertices < 3)
			{
				throw new Exception("Input must have at least three input vertices.");
			}

			bool flag = points[0].id != points[1].id;
			foreach (Vertex point in points)
			{
				if (flag)
				{
					point.hash = point.id;
					hash_vtx = Math.Max(point.hash + 1, hash_vtx);
				}
				else
				{
					point.hash = (point.id = hash_vtx++);
				}

				vertices.Add(point.hash, point);
				bounds.Expand(point);
			}
		}

		private void Initialize()
		{
			dummysub = new SubSegment();
			dummysub.hash = -1;
			dummysub.subsegs[0].seg = dummysub;
			dummysub.subsegs[1].seg = dummysub;
			dummytri = new Triangle();
			dummytri.hash = (dummytri.id = -1);
			dummytri.neighbors[0].tri = dummytri;
			dummytri.neighbors[1].tri = dummytri;
			dummytri.neighbors[2].tri = dummytri;
			dummytri.subsegs[0].seg = dummysub;
			dummytri.subsegs[1].seg = dummysub;
			dummytri.subsegs[2].seg = dummysub;
		}

		internal void TriangleDealloc(Triangle dyingtriangle)
		{
			Otri.Kill(dyingtriangle);
			triangles.Release(dyingtriangle);
		}
	}
}
