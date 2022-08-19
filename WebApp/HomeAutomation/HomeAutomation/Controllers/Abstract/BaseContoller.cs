using HomeAutomation.Data;
using HomeAutomation.Responces.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HomeAutomation.Controllers.Abstract
{
	public abstract class BaseContoller<T> : ControllerBase
	{
		protected BaseContoller(
			ILogger<T> logger,
			ITransactionBl transactionBl)
		{
			this.logger = logger;
			this.transactionBl = transactionBl;
		}

		public readonly ILogger<T> logger;
		private readonly ITransactionBl transactionBl;

		/// <summary>
		/// </summary>
		/// <typeparam name="RT">type of return data</typeparam>
		/// <param name="block">block to execute</param>
		/// <returns>return data</returns>
		protected async Task<ActionResult<RT>> ExecAsync<RT>(Func<Task<ActionResult<RT>>> block, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
			where RT : BaseResponce
		{
			try
			{
				await transactionBl.BeginAsync(isolationLevel);

				var ret = await block.Invoke();

				await transactionBl.CommitAsync();
				return ret;
			}
			catch (Exception ex)
			{
				await transactionBl.RollbackAsync();
				logger.LogWarning(ex, "Default exception");
				return StatusCode(400, ex.Message);
			}
		}
	}
}
