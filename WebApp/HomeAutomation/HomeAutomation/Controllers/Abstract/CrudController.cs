using HomeAutomation.Data;
using HomeAutomation.Data.Bl.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomation.Controllers.Abstract
{
	public abstract class CrudController<T, DTO, FLT, BL> : ReadController<T, DTO, FLT, BL>
		where DTO : dto.Abstract.BaseDto
		where FLT : flt.BaseFilter
	{
		private readonly ICrudBl<DTO, FLT> crudBl;

		public CrudController(
			ILogger<T> logger,
			ITransactionBl transactionBl,
			ICrudBl<DTO, FLT> crudBl
			) : base(logger, transactionBl, crudBl)
		{
			this.crudBl = crudBl;
		}

		/// <summary>
		/// Updates creates dto
		/// </summary>
		/// <returns></returns>
		[HttpPut("")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<ValueResponce<DTO>>> Create([FromBody] DTO dto)
		{
			return await ExecAsync<ValueResponce<DTO>>(async () =>
			{
				return new ValueResponce<DTO>(await this.crudBl.CreateAsnyc(dto));
			});
		}

		/// <summary>
		/// Updates existing dto
		/// </summary>
		/// <returns></returns>
		[HttpPost("")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<ValueResponce<DTO>>> Update([FromBody] DTO dto)
		{
			return await ExecAsync<ValueResponce<DTO>>(async () =>
			{
				return new ValueResponce<DTO>(await this.crudBl.UpdateAsync(dto));
			});
		}

		/// <summary>
		/// Deletes existing dto
		/// </summary>
		/// <returns></returns>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<DeleteResponce>> Delete(int id)
		{
			return await ExecAsync<DeleteResponce>(async () =>
			{
				await this.crudBl.DeleteAsync(id);
				return new DeleteResponce();
			});
		}
	}
}
