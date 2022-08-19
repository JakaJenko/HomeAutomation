using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomation.Data.Bl.Abstract
{
	public class BaseBl<T>
	{
		protected readonly ILogger<T> logger;
		protected readonly HomeAutomationContext context;

		public BaseBl(
			ILogger<T> logger,
			HomeAutomationContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		protected static async Task<RT> ExecAsync<RT>(Func<Task<RT>> block)
		{
			try
			{
				return await block.Invoke();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				throw new Exception($"Data has been changed elsewhere.", ex);
			}
		}

		protected static async Task ExecAsync(Func<Task> block)
		{
			try
			{
				await block.Invoke();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				throw new Exception($"Data has been changed elsewhere.", ex);
			}
		}
	}
}
