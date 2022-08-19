using HomeAutomation.Data;
using Microsoft.AspNetCore.Mvc;
using HomeAutomation.Data.Bl.Abstract;

namespace HomeAutomation.Controllers.Abstract
{
	public abstract class ReadController<T, DTO, FLT, BL> : BaseContoller<T>
		where DTO : dto.Abstract.BaseDto
		where FLT : flt.BaseFilter
	{
		private readonly IReadBl<DTO, FLT> readBl;

		public ReadController(
			ILogger<T> logger,
			ITransactionBl transactionBl,
			IReadBl<DTO, FLT> readBl
			) : base(logger, transactionBl)
		{
			this.readBl = readBl;
		}

		/// <summary>
		/// Gets list by filter
		/// </summary>
		/// <returns></returns>
		[HttpGet("")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<ListResponce<DTO>>> GetAll(int skip = 0, int? take = null)
		{
			return await ExecAsync<ListResponce<DTO>>(async () =>
			{
				return new ListResponce<DTO>(await this.readBl.ListAsync(skip, take));
			});
		}

		/// <summary>
		/// Gets list by filter
		/// </summary>
		/// <returns></returns>
		[HttpPost("Filter")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<ListResponce<DTO>>> GetAllFilter(int skip = 0, int? take = null, [FromBody] FLT? filter = null)
		{
			return await ExecAsync<ListResponce<DTO>>(async () =>
			{
				return new ListResponce<DTO>(await this.readBl.ListAsync(skip, take, filter));
			});
		}

		/// <summary>
		/// Gets one by id
		/// </summary>
		/// <returns></returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<ValueResponce<DTO>>> Get(int id)
		{
			return await ExecAsync<ValueResponce<DTO>>(async () =>
			{
				return new ValueResponce<DTO>(await this.readBl.ReadAsync(id));
			});
		}
	}
}
