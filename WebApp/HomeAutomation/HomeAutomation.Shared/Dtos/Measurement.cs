using HomeAutomation.Shared.Dtos.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomation.Shared.Dtos
{
	public class Measurement : BaseDto
	{
		[Required]
		public string Raw { get; set; } = null!;
		
		[Required]
		public DateTime DateTime { get; set; }
	}
}
