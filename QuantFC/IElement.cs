namespace QuantFC {
	public interface IElement
	{
		string Title { get; }
		int NextCount { get; }
	}

	public interface IElement<T>: IElement
	{
		T Run(T state, out int ret);
	}
}
