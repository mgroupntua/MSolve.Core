using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGroup.MSolve.Discretization.Dofs
{
	public class ActiveDofs
	{
		private readonly Dictionary<int, IDofType> idsToDofs = new Dictionary<int, IDofType>();
		private readonly Dictionary<IDofType, int> dofsToIds = new Dictionary<IDofType, int>();
		private readonly object insertionLock = new object();
		private int nextId = 0;

		public void AddDof(IDofType dof)
		{
			lock (insertionLock)
			{
				bool exists = dofsToIds.ContainsKey(dof);
				if (!exists)
				{
					dofsToIds[dof] = nextId;
					idsToDofs[nextId] = dof;
					++nextId;
				}
			}
		}

		public void Clear()
		{
			lock (insertionLock)
			{
				idsToDofs.Clear();
				dofsToIds.Clear();
				nextId = 0;
			}
		}

		public SortedDictionary<int, IDofType> SortDofs()
		{
			return new SortedDictionary<int, IDofType>(idsToDofs);
		}

		public int GetIdOfDof(IDofType dof) => dofsToIds[dof];

		public IDofType GetDofWithId(int id) => idsToDofs[id];

		public void RemoveDof(IDofType dof)
		{
			lock (insertionLock)
			{
				bool exists = dofsToIds.ContainsKey(dof);
				if (exists)
				{
					idsToDofs.Remove(dofsToIds[dof]);
				}
			}
		}
	}
}
