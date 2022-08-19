namespace HomeAutomation.Data.Bl
{
	public interface ISensorBl : ICrudBl<dto.Sensor, flt.BaseFilter> { }

	public class SensorBl : CrudBl<SensorBl, dto.Sensor, ent.Sensor, flt.BaseFilter>, ISensorBl
	{
		public SensorBl(
			ILogger<SensorBl> logger,
			HomeAutomationContext context)
			: base(logger, context)
		{ }

		public override string EntName => "Sensors";

		protected override async Task<Entities.Sensor> DtoToEntAsync(dto.Sensor dto, ent.Sensor ent)
		{
			ent.Name = dto.Name;
			ent.CodeVersion = dto.CodeVersion;

			var sensorType = await this.context.SensorTypes
				.FirstOrDefaultAsync(x => x.ID == dto.SensorTypeID);

			if (sensorType == null)
				throw new Exception($"SensorType with ID {dto.SensorTypeID} not found.");

			ent.SensorTypeID = sensorType.ID;


			var location = await this.context.Locations
				.FirstOrDefaultAsync(x => x.ID == dto.LocationID);

			if (location == null)
				throw new Exception($"Location with ID {dto.LocationID} not found.");

			ent.LocationID = location.ID;


			return ent;
		}

		protected override Task<dto.Sensor> EntToDtoAsync(ent.Sensor ent)
		{
			var sensor = new dto.Sensor();

			sensor.Name = ent.Name;
			sensor.CodeVersion = ent.CodeVersion;
			sensor.SensorTypeID = ent.SensorTypeID;
			sensor.LocationID = ent.LocationID;

			return Task.FromResult(sensor);
		}

		protected override IQueryable<Entities.Sensor> OrderListAsync(IQueryable<Entities.Sensor> query, flt.BaseFilter? filter = null)
		{
			return query.OrderBy(x => x.ID);
		}
	}
}
