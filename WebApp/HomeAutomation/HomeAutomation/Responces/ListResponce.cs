using HomeAutomation.Responces.Abstract;

namespace HomeAutomation.Responces
{
	public class ListResponce<T> : BaseResponce
	{
		public ListResponce(List<T> values)
		{
			this.Values = values;
			this.Count = values.Count;
		}

		public List<T> Values { get; set; } = new List<T>();
		public int Count { get; set; }
	}
}
