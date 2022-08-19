namespace HomeAutomation.Data.Bl
{
	public interface ISensorTypeBl : ICrudBl<dto.SensorType, flt.BaseFilter> { }

	public class SensorTypeBl : CrudBl<SensorTypeBl, dto.SensorType, ent.SensorType, flt.BaseFilter>, ISensorTypeBl
	{
		public SensorTypeBl(
			ILogger<SensorTypeBl> logger,
			HomeAutomationContext context)
			: base(logger, context)
		{ }

		public override string EntName => "Sensors";

		protected override Task<Entities.SensorType> DtoToEntAsync(dto.SensorType dto, ent.SensorType ent)
		{
			ent.Name = dto.Name;
			ent.Description = dto.Description;

			return Task.FromResult(ent);
		}

		protected override Task<dto.SensorType> EntToDtoAsync(ent.SensorType ent)
		{
			var sensorType = new dto.SensorType();

			sensorType.Name = ent.Name;
			sensorType.Description = ent.Description;

			return Task.FromResult(sensorType);
		}

		protected override IQueryable<Entities.SensorType> OrderListAsync(IQueryable<Entities.SensorType> query, flt.BaseFilter? filter = null)
		{
			return query.OrderBy(x => x.ID);
		}
	}
}
