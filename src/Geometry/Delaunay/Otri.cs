namespace MGroup.MSolve.Core.Geometry.Delaunay
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	internal struct Otri
	{
		private static readonly int[] minus1Mod3 = new int[3] { 2, 0, 1 };
		private static readonly int[] plus1Mod3 = new int[3] { 1, 2, 0 };

		internal Triangle tri;
		internal int orient;

		public Vertex Apex()
		{
			return tri.vertices[orient];
		}

		internal void Bond(ref Otri ot)
		{
			tri.neighbors[orient].tri = ot.tri;
			tri.neighbors[orient].orient = ot.orient;
			ot.tri.neighbors[ot.orient].tri = tri;
			ot.tri.neighbors[ot.orient].orient = orient;
		}

		public void Copy(ref Otri ot)
		{
			ot.tri = tri;
			ot.orient = orient;
		}

		public Vertex Dest()
		{
			return tri.vertices[minus1Mod3[orient]];
		}

		internal void Dissolve(Triangle dummy)
		{
			tri.neighbors[orient].tri = dummy;
			tri.neighbors[orient].orient = 0;
		}

		public bool Equals(Otri ot)
		{
			if (tri == ot.tri)
			{
				return orient == ot.orient;
			}

			return false;
		}

		internal static void Kill(Triangle tri)
		{
			tri.neighbors[0].tri = null;
			tri.neighbors[2].tri = null;
		}

		public void Lnext()
		{
			orient = plus1Mod3[orient];
		}

		public void Lnext(ref Otri ot)
		{
			ot.tri = tri;
			ot.orient = plus1Mod3[orient];
		}

		public void Lprev()
		{
			orient = minus1Mod3[orient];
		}

		public void Lprev(ref Otri ot)
		{
			ot.tri = tri;
			ot.orient = minus1Mod3[orient];
		}

		public Vertex Org()
		{
			return tri.vertices[plus1Mod3[orient]];
		}

		internal void SetApex(Vertex v)
		{
			tri.vertices[orient] = v;
		}

		internal void SetDest(Vertex v)
		{
			tri.vertices[minus1Mod3[orient]] = v;
		}

		internal void SetOrg(Vertex v)
		{
			tri.vertices[plus1Mod3[orient]] = v;
		}

		public void Sym()
		{
			int num = orient;
			orient = tri.neighbors[num].orient;
			tri = tri.neighbors[num].tri;
		}

		public void Sym(ref Otri ot)
		{
			ot.tri = tri.neighbors[orient].tri;
			ot.orient = tri.neighbors[orient].orient;
		}
	}
}
