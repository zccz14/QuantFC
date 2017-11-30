namespace QuantFC
{
	public interface IRedirectionNode<in T>
	{
		/// <summary>
		/// Input a state and get exit id
		/// </summary>
		/// <param name="state"></param>
		/// <returns></returns>
		int Next(T state);
	}
}