using HomeAutomation.Controllers.Abstract;
using HomeAutomation.Data;
using HomeAutomation.Data.Bl;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomation.Controllers
{
	[Route("api/sensors")]
	public class SensorController : CrudController<SensorController, dto.Sensor, flt.BaseFilter, Data.Bl.SensorBl>
	{
		public SensorController(ILogger<SensorController> logger,
			ITransactionBl transactionBl,
			ISensorBl sensorBl)
			: base(logger, transactionBl, sensorBl)
		{

		}
	}
}
