namespace MGroup.MSolve.Solution.LinearSystem
{
	/// <summary>
	/// Objects implementing this interface will be notifying when the matrix of the linear system is modified.
	/// Authors: Serafeim Bakalakos
	/// </summary>
	public interface ILinearSystemObserver
    {
		/// <summary>
		/// It will be called before setting <see cref="IGlobalLinearSystem.Matrix"/>.
		/// </summary>
		void HandleMatrixWillBeSet(); 
		//TODO: Why notify before changing the matrix instead of after. I assume it is to dispose unmanaged arrays. Shouldn't that be handled by destructors though? 
    }
}
