namespace MGroup.MSolve.Core.Geometry.Delaunay
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	internal class Dwyer : ITriangulator
	{
		private Random rand = new Random(DateTime.Now.Millisecond);

		private IPredicates predicates;

		public bool UseDwyer = true;

		private Vertex[] sortarray;

		private Mesh mesh;

		public bool VerboseLogging { get; set; }

		public Mesh Triangulate(IList<Vertex> points, Configuration config)
		{
			predicates = config.Predicates();
			mesh = new Mesh(config);
			mesh.TransferNodes(points);
			var farleft = default(Otri);
			var farright = default(Otri);
			var count = points.Count;
			sortarray = new Vertex[count];
			var num = 0;
			foreach (var point in points)
			{
				sortarray[num++] = point;
			}

			VertexSort(0, count - 1);
			num = 0;
			for (var i = 1; i < count; i++)
			{
				if (sortarray[num].x == sortarray[i].x && sortarray[num].y == sortarray[i].y)
				{
					if (VerboseLogging)
					{
						var msg = $"Warning by Dwyer.Triangulate(): A duplicate vertex appeared and was ignored (ID {sortarray[i].id}).";
					}

					sortarray[i].type = VertexType.UndeadVertex;
					mesh.undeads++;
				}
				else
				{
					num++;
					sortarray[num] = sortarray[i];
				}
			}

			num++;
			if (UseDwyer)
			{
				var num2 = num >> 1;
				if (num - num2 >= 2)
				{
					if (num2 >= 2)
					{
						AlternateAxes(0, num2 - 1, 1);
					}

					AlternateAxes(num2, num - 1, 1);
				}
			}

			DivconqRecurse(0, num - 1, 0, ref farleft, ref farright);
			mesh.hullsize = RemoveGhosts(ref farleft);
			return mesh;
		}

		private void VertexSort(int left, int right)
		{
			var num = left;
			var num2 = right;
			if (right - left + 1 < 32)
			{
				for (var i = left + 1; i <= right; i++)
				{
					var vertex = sortarray[i];
					var num3 = i - 1;
					while (num3 >= left && (sortarray[num3].x > vertex.x || sortarray[num3].x == vertex.x && sortarray[num3].y > vertex.y))
					{
						sortarray[num3 + 1] = sortarray[num3];
						num3--;
					}

					sortarray[num3 + 1] = vertex;
				}

				return;
			}

			var num4 = rand.Next(left, right);
			var x = sortarray[num4].x;
			var y = sortarray[num4].y;
			left--;
			right++;
			while (left < right)
			{
				do
				{
					left++;
				}
				while (left <= right && (sortarray[left].x < x || sortarray[left].x == x && sortarray[left].y < y));
				do
				{
					right--;
				}
				while (left <= right && (sortarray[right].x > x || sortarray[right].x == x && sortarray[right].y > y));
				if (left < right)
				{
					var vertex2 = sortarray[left];
					sortarray[left] = sortarray[right];
					sortarray[right] = vertex2;
				}
			}

			if (left > num)
			{
				VertexSort(num, left);
			}

			if (num2 > right + 1)
			{
				VertexSort(right + 1, num2);
			}
		}

		private void VertexMedian(int left, int right, int median, int axis)
		{
			var num = right - left + 1;
			var left2 = left;
			var right2 = right;
			if (num == 2)
			{
				if (sortarray[left][axis] > sortarray[right][axis] || sortarray[left][axis] == sortarray[right][axis] && sortarray[left][1 - axis] > sortarray[right][1 - axis])
				{
					var vertex = sortarray[right];
					sortarray[right] = sortarray[left];
					sortarray[left] = vertex;
				}

				return;
			}

			var num2 = rand.Next(left, right);
			var num3 = sortarray[num2][axis];
			var num4 = sortarray[num2][1 - axis];
			left--;
			right++;
			while (left < right)
			{
				do
				{
					left++;
				}
				while (left <= right && (sortarray[left][axis] < num3 || sortarray[left][axis] == num3 && sortarray[left][1 - axis] < num4));
				do
				{
					right--;
				}
				while (left <= right && (sortarray[right][axis] > num3 || sortarray[right][axis] == num3 && sortarray[right][1 - axis] > num4));
				if (left < right)
				{
					var vertex = sortarray[left];
					sortarray[left] = sortarray[right];
					sortarray[right] = vertex;
				}
			}

			if (left > median)
			{
				VertexMedian(left2, left - 1, median, axis);
			}

			if (right < median - 1)
			{
				VertexMedian(right + 1, right2, median, axis);
			}
		}

		private void AlternateAxes(int left, int right, int axis)
		{
			var num = right - left + 1;
			var num2 = num >> 1;
			if (num <= 3)
			{
				axis = 0;
			}

			VertexMedian(left, right, left + num2, axis);
			if (num - num2 >= 2)
			{
				if (num2 >= 2)
				{
					AlternateAxes(left, left + num2 - 1, 1 - axis);
				}

				AlternateAxes(left + num2, right, 1 - axis);
			}
		}

		private void MergeHulls(ref Otri farleft, ref Otri innerleft, ref Otri innerright, ref Otri farright, int axis)
		{
			var ot = default(Otri);
			var ot2 = default(Otri);
			var ot3 = default(Otri);
			var ot4 = default(Otri);
			var ot5 = default(Otri);
			var ot6 = default(Otri);
			var ot7 = default(Otri);
			var newotri = default(Otri);
			Vertex vertex = innerleft.Dest();
			Vertex vertex2 = innerleft.Apex();
			Vertex vertex3 = innerright.Org();
			Vertex vertex4 = innerright.Apex();
			Vertex vertex5;
			Vertex vertex7;
			if (UseDwyer && axis == 1)
			{
				vertex5 = farleft.Org();
				Vertex vertex6 = farleft.Apex();
				vertex7 = farright.Dest();
				Vertex vertex8 = farright.Apex();
				while (vertex6.y < vertex5.y)
				{
					farleft.Lnext();
					farleft.Sym();
					vertex5 = vertex6;
					vertex6 = farleft.Apex();
				}

				innerleft.Sym(ref ot7);
				Vertex vertex9 = ot7.Apex();
				while (vertex9.y > vertex.y)
				{
					ot7.Lnext(ref innerleft);
					vertex2 = vertex;
					vertex = vertex9;
					innerleft.Sym(ref ot7);
					vertex9 = ot7.Apex();
				}

				while (vertex4.y < vertex3.y)
				{
					innerright.Lnext();
					innerright.Sym();
					vertex3 = vertex4;
					vertex4 = innerright.Apex();
				}

				farright.Sym(ref ot7);
				vertex9 = ot7.Apex();
				while (vertex9.y > vertex7.y)
				{
					ot7.Lnext(ref farright);
					vertex8 = vertex7;
					vertex7 = vertex9;
					farright.Sym(ref ot7);
					vertex9 = ot7.Apex();
				}
			}

			bool flag;
			do
			{
				flag = false;
				if (predicates.CounterClockwise(vertex, vertex2, vertex3) > 0.0)
				{
					innerleft.Lprev();
					innerleft.Sym();
					vertex = vertex2;
					vertex2 = innerleft.Apex();
					flag = true;
				}

				if (predicates.CounterClockwise(vertex4, vertex3, vertex) > 0.0)
				{
					innerright.Lnext();
					innerright.Sym();
					vertex3 = vertex4;
					vertex4 = innerright.Apex();
					flag = true;
				}
			}
			while (flag);
			innerleft.Sym(ref ot);
			innerright.Sym(ref ot2);
			mesh.MakeTriangle(ref newotri);
			newotri.Bond(ref innerleft);
			newotri.Lnext();
			newotri.Bond(ref innerright);
			newotri.Lnext();
			newotri.SetOrg(vertex3);
			newotri.SetDest(vertex);
			vertex5 = farleft.Org();
			if (vertex == vertex5)
			{
				newotri.Lnext(ref farleft);
			}

			vertex7 = farright.Dest();
			if (vertex3 == vertex7)
			{
				newotri.Lprev(ref farright);
			}

			var vertex10 = vertex;
			var vertex11 = vertex3;
			Vertex vertex12 = ot.Apex();
			Vertex vertex13 = ot2.Apex();
			while (true)
			{
				var flag2 = predicates.CounterClockwise(vertex12, vertex10, vertex11) <= 0.0;
				var flag3 = predicates.CounterClockwise(vertex13, vertex10, vertex11) <= 0.0;
				if (flag2 && flag3)
				{
					break;
				}

				if (!flag2)
				{
					ot.Lprev(ref ot3);
					ot3.Sym();
					Vertex vertex14 = ot3.Apex();
					if (vertex14 != null)
					{
						var flag4 = predicates.InCircle(vertex10, vertex11, vertex12, vertex14) > 0.0;
						while (flag4)
						{
							ot3.Lnext();
							ot3.Sym(ref ot5);
							ot3.Lnext();
							ot3.Sym(ref ot4);
							ot3.Bond(ref ot5);
							ot.Bond(ref ot4);
							ot.Lnext();
							ot.Sym(ref ot6);
							ot3.Lprev();
							ot3.Bond(ref ot6);
							ot.SetOrg(vertex10);
							ot.SetDest(null);
							ot.SetApex(vertex14);
							ot3.SetOrg(null);
							ot3.SetDest(vertex12);
							ot3.SetApex(vertex14);
							vertex12 = vertex14;
							ot4.Copy(ref ot3);
							vertex14 = ot3.Apex();
							flag4 = vertex14 != null && predicates.InCircle(vertex10, vertex11, vertex12, vertex14) > 0.0;
						}
					}
				}

				if (!flag3)
				{
					ot2.Lnext(ref ot3);
					ot3.Sym();
					Vertex vertex14 = ot3.Apex();
					if (vertex14 != null)
					{
						var flag4 = predicates.InCircle(vertex10, vertex11, vertex13, vertex14) > 0.0;
						while (flag4)
						{
							ot3.Lprev();
							ot3.Sym(ref ot5);
							ot3.Lprev();
							ot3.Sym(ref ot4);
							ot3.Bond(ref ot5);
							ot2.Bond(ref ot4);
							ot2.Lprev();
							ot2.Sym(ref ot6);
							ot3.Lnext();
							ot3.Bond(ref ot6);
							ot2.SetOrg(null);
							ot2.SetDest(vertex11);
							ot2.SetApex(vertex14);
							ot3.SetOrg(vertex13);
							ot3.SetDest(null);
							ot3.SetApex(vertex14);
							vertex13 = vertex14;
							ot4.Copy(ref ot3);
							vertex14 = ot3.Apex();
							flag4 = vertex14 != null && predicates.InCircle(vertex10, vertex11, vertex13, vertex14) > 0.0;
						}
					}
				}

				if (flag2 || !flag3 && predicates.InCircle(vertex12, vertex10, vertex11, vertex13) > 0.0)
				{
					newotri.Bond(ref ot2);
					ot2.Lprev(ref newotri);
					newotri.SetDest(vertex10);
					vertex11 = vertex13;
					newotri.Sym(ref ot2);
					vertex13 = ot2.Apex();
				}
				else
				{
					newotri.Bond(ref ot);
					ot.Lnext(ref newotri);
					newotri.SetOrg(vertex11);
					vertex10 = vertex12;
					newotri.Sym(ref ot);
					vertex12 = ot.Apex();
				}
			}

			mesh.MakeTriangle(ref ot3);
			ot3.SetOrg(vertex10);
			ot3.SetDest(vertex11);
			ot3.Bond(ref newotri);
			ot3.Lnext();
			ot3.Bond(ref ot2);
			ot3.Lnext();
			ot3.Bond(ref ot);
			if (UseDwyer && axis == 1)
			{
				vertex5 = farleft.Org();
				Vertex vertex6 = farleft.Apex();
				vertex7 = farright.Dest();
				Vertex vertex8 = farright.Apex();
				farleft.Sym(ref ot7);
				Vertex vertex9 = ot7.Apex();
				while (vertex9.x < vertex5.x)
				{
					ot7.Lprev(ref farleft);
					vertex6 = vertex5;
					vertex5 = vertex9;
					farleft.Sym(ref ot7);
					vertex9 = ot7.Apex();
				}

				while (vertex8.x > vertex7.x)
				{
					farright.Lprev();
					farright.Sym();
					vertex7 = vertex8;
					vertex8 = farright.Apex();
				}
			}
		}

		private void DivconqRecurse(int left, int right, int axis, ref Otri farleft, ref Otri farright)
		{
			var newotri = default(Otri);
			var newotri2 = default(Otri);
			var newotri3 = default(Otri);
			var newotri4 = default(Otri);
			var farright2 = default(Otri);
			var farleft2 = default(Otri);
			var num = right - left + 1;
			switch (num)
			{
				case 2:
					mesh.MakeTriangle(ref farleft);
					farleft.SetOrg(sortarray[left]);
					farleft.SetDest(sortarray[left + 1]);
					mesh.MakeTriangle(ref farright);
					farright.SetOrg(sortarray[left + 1]);
					farright.SetDest(sortarray[left]);
					farleft.Bond(ref farright);
					farleft.Lprev();
					farright.Lnext();
					farleft.Bond(ref farright);
					farleft.Lprev();
					farright.Lnext();
					farleft.Bond(ref farright);
					farright.Lprev(ref farleft);
					break;
				case 3:
					{
						mesh.MakeTriangle(ref newotri);
						mesh.MakeTriangle(ref newotri2);
						mesh.MakeTriangle(ref newotri3);
						mesh.MakeTriangle(ref newotri4);
						double num3 = predicates.CounterClockwise(sortarray[left], sortarray[left + 1], sortarray[left + 2]);
						if (num3 == 0.0)
						{
							newotri.SetOrg(sortarray[left]);
							newotri.SetDest(sortarray[left + 1]);
							newotri2.SetOrg(sortarray[left + 1]);
							newotri2.SetDest(sortarray[left]);
							newotri3.SetOrg(sortarray[left + 2]);
							newotri3.SetDest(sortarray[left + 1]);
							newotri4.SetOrg(sortarray[left + 1]);
							newotri4.SetDest(sortarray[left + 2]);
							newotri.Bond(ref newotri2);
							newotri3.Bond(ref newotri4);
							newotri.Lnext();
							newotri2.Lprev();
							newotri3.Lnext();
							newotri4.Lprev();
							newotri.Bond(ref newotri4);
							newotri2.Bond(ref newotri3);
							newotri.Lnext();
							newotri2.Lprev();
							newotri3.Lnext();
							newotri4.Lprev();
							newotri.Bond(ref newotri2);
							newotri3.Bond(ref newotri4);
							newotri2.Copy(ref farleft);
							newotri3.Copy(ref farright);
							break;
						}

						newotri.SetOrg(sortarray[left]);
						newotri2.SetDest(sortarray[left]);
						newotri4.SetOrg(sortarray[left]);
						if (num3 > 0.0)
						{
							newotri.SetDest(sortarray[left + 1]);
							newotri2.SetOrg(sortarray[left + 1]);
							newotri3.SetDest(sortarray[left + 1]);
							newotri.SetApex(sortarray[left + 2]);
							newotri3.SetOrg(sortarray[left + 2]);
							newotri4.SetDest(sortarray[left + 2]);
						}
						else
						{
							newotri.SetDest(sortarray[left + 2]);
							newotri2.SetOrg(sortarray[left + 2]);
							newotri3.SetDest(sortarray[left + 2]);
							newotri.SetApex(sortarray[left + 1]);
							newotri3.SetOrg(sortarray[left + 1]);
							newotri4.SetDest(sortarray[left + 1]);
						}

						newotri.Bond(ref newotri2);
						newotri.Lnext();
						newotri.Bond(ref newotri3);
						newotri.Lnext();
						newotri.Bond(ref newotri4);
						newotri2.Lprev();
						newotri3.Lnext();
						newotri2.Bond(ref newotri3);
						newotri2.Lprev();
						newotri4.Lprev();
						newotri2.Bond(ref newotri4);
						newotri3.Lnext();
						newotri4.Lprev();
						newotri3.Bond(ref newotri4);
						newotri2.Copy(ref farleft);
						if (num3 > 0.0)
						{
							newotri3.Copy(ref farright);
						}
						else
						{
							farleft.Lnext(ref farright);
						}

						break;
					}
				default:
					{
						var num2 = num >> 1;
						DivconqRecurse(left, left + num2 - 1, 1 - axis, ref farleft, ref farright2);
						DivconqRecurse(left + num2, right, 1 - axis, ref farleft2, ref farright);
						MergeHulls(ref farleft, ref farright2, ref farleft2, ref farright, axis);
						break;
					}
			}
		}

		private int RemoveGhosts(ref Otri startghost)
		{
			var ot = default(Otri);
			var ot2 = default(Otri);
			var ot3 = default(Otri);
			bool flag = !mesh.behavior.Poly;
			startghost.Lprev(ref ot);
			ot.Sym();
			mesh.dummytri.neighbors[0] = ot;
			startghost.Copy(ref ot2);
			var num = 0;
			do
			{
				num++;
				ot2.Lnext(ref ot3);
				ot2.Lprev();
				ot2.Sym();
				if (flag && ot2.tri.id != -1)
				{
					Vertex vertex = ot2.Org();
					if (vertex.label == 0)
					{
						vertex.label = 1;
					}
				}

				ot2.Dissolve(mesh.dummytri);
				ot3.Sym(ref ot2);
				mesh.TriangleDealloc(ot3.tri);
			}
			while (!ot2.Equals(startghost));
			return num;
		}
	}
}
