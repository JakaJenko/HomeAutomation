using HomeAutomation.Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomation.Data.Entities
{
	[Table("Locations")]
	public class Location : BaseEntity
	{
		public string Name { get; set; } = null!;
		public string? Description { get; set; }

		public ICollection<Sensor> Sensors { get; set; } = null!;
	}
}
