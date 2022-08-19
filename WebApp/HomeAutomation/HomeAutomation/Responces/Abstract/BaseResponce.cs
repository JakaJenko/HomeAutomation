namespace HomeAutomation.Responces.Abstract
{
	public abstract class BaseResponce
	{
		public BaseResponce()
		{
			ReturnCode = ReturnCode;
		}

		public BaseResponce(string returnCode, string returnMsg)
		{
			ReturnCode = returnCode;
			ReturnMsg = returnMsg;
		}

		public string ReturnCode { get; set; } = null!;
		public string ReturnMsg { get; set; } = null!;
	}
}
