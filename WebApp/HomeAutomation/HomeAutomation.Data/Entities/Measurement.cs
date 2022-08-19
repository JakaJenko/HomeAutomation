using HomeAutomation.Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomation.Data.Entities
{
    [Table("Measurements")]
    public class Measurement : BaseEntity
    {
        public string Raw { get; set; } = null!;
        public DateTime DateTime { get; set; }

        public int SensorID { get; set; }
        public Sensor Sensor { get; set; } = null!;
    }
}
