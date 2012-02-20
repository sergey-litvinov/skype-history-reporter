namespace SkypeHistory.Infrastructure.Net4Utils
{
	public class Tuple<T>
	{
		public Tuple(T item1)
		{
			Item1 = item1;
		}

		public T Item1 { get; set; }
	}

	public class Tuple<T1, T2>
	{
		public Tuple(T1 item1, T2 item2)
		{
			Item1 = item1;
			Item2 = item2;
		}

		public T1 Item1 { get; set; }
		public T2 Item2 { get; set; }
	}

}