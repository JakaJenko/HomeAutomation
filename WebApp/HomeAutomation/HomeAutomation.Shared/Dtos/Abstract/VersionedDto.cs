using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomation.Shared.Dtos.Abstract
{
	public abstract class VersionedDto : BaseDto
	{
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
	}
}
