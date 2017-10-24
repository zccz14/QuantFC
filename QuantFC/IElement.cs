namespace QuantFC {
	public interface IElement
	{
		string Title { get; }
	}

	public interface IElement<T>: IElement
	{
		T Run(T state, out int ret);
	}
}
