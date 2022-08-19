using HomeAutomation.Shared.Dtos.Abstract;
using System.ComponentModel.DataAnnotations;

namespace HomeAutomation.Shared.Dtos
{
	public class Location : BaseDto
	{
		[Required]
		public string Name { get; set; } = null!;
		public string? Description { get; set; }

		public List<Sensor> Sensors { get; set; } = null!;
	}
}
