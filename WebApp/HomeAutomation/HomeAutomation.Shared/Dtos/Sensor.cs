using HomeAutomation.Shared.Dtos.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomation.Shared.Dtos
{
	public class Sensor : VersionedDto
	{
		[Required]
        public string Name { get; set; } = null!;

        [Required]
        public int SensorTypeID { get; set; }

        [Required]
        public int LocationID { get; set; }
        public int? CodeVersion { get; set; }
    }
}
