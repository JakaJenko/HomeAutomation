using HomeAutomation.Shared.Dtos.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomation.Shared.Dtos
{
	public class SensorType : BaseDto
	{
		[Required]
		public string Name { get; set; } = null!;
		public string? Description { get; set; }

		public List<Sensor> Sensors { get; set; } = null!;
	}
}
