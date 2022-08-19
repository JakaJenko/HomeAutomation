using HomeAutomation.Responces.Abstract;

namespace HomeAutomation.Responces
{
	public class ValueResponce<T> : BaseResponce
	{
		public ValueResponce(T value)
		{
			this.Value = value;
		}

		public T Value { get; set; }
	}
}
