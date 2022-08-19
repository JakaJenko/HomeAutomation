using HomeAutomation.Controllers.Abstract;
using HomeAutomation.Data;
using HomeAutomation.Data.Bl;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomation.Controllers
{
	[Route("api/sensorTypes")]
	public class SensorTypeController : CrudController<SensorController, dto.SensorType, flt.BaseFilter, Data.Bl.SensorTypeBl>
	{
		public SensorTypeController(ILogger<SensorController> logger,
			ITransactionBl transactionBl,
			ISensorTypeBl sensorTypeBl)
			: base(logger, transactionBl, sensorTypeBl)
		{

		}
	}
}
