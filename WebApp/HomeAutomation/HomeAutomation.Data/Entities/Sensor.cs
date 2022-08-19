using HomeAutomation.Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomation.Data.Entities
{
    [Table("Sensors")]
    public class Sensor : VersionedEntity
    {
        public string Name { get; set; } = null!;
        public int SensorTypeID { get; set; }
        public int LocationID { get; set; }
        public int? CodeVersion { get; set; }

        public Location Location { get; set; } = null!;
        public SensorType SensorType { get; set; } = null!;
    }
}
