using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomation.Data.Entities.Abstract
{
	public abstract class VersionedEntity : BaseEntity
	{
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
	}
}
