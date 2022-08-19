using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomation.Data
{
	public interface ITransactionBl
	{
		Task BeginAsync(IsolationLevel isolationLevel);
		Task CommitAsync();
		Task RollbackAsync();
	}

	public class TransactionBl : BaseBl<TransactionBl>, ITransactionBl
	{
		public TransactionBl(
			ILogger<TransactionBl> logger,
			HomeAutomationContext context
			) : base(logger, context)
		{ }

		public async Task BeginAsync(IsolationLevel isolationLevel)
		{
			if (this.context.Database.CurrentTransaction != null)
				throw new SystemException("Transaction is already started.");

			if (!await this.context.Database.CanConnectAsync())
				logger.LogCritical("Can't connect to database!");

			await this.context.Database.BeginTransactionAsync(isolationLevel);
		}

		public async Task CommitAsync()
		{
			if (this.context.Database.CurrentTransaction == null)
				throw new SystemException("There is no active transaction.");

			await this.context.SaveChangesAsync();
			await this.context.Database.CommitTransactionAsync();
		}

		public async Task RollbackAsync()
		{
			if (this.context.Database.CurrentTransaction == null)
				throw new SystemException("There is no active transaction.");

			await this.context.Database.RollbackTransactionAsync();
		}
	}
}
