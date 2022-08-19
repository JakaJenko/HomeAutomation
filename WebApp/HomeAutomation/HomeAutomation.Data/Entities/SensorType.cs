using HomeAutomation.Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomation.Data.Entities
{
	[Table("SensorTypes")]
    public class SensorType : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<Sensor> Sensors { get; set; } = null!;
    }
}
