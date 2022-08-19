using HomeAutomation.Data.Entities.Abstract;

namespace HomeAutomation.Data.Bl.Abstract
{
	public interface ICrudBl<DTO, FLT> : IReadBl<DTO, FLT>
		where DTO : dto.Abstract.BaseDto
		where FLT : flt.BaseFilter
	{
		Task<DTO> CreateAsnyc(DTO dto);
		Task<DTO> UpdateAsync(DTO dto);
		Task DeleteAsync(int id);
	}

	public abstract class CrudBl<T, DTO, ENT, FLT> : ReadBl<T, DTO, ENT, FLT>, ICrudBl<DTO, FLT>
		where T : CrudBl<T, DTO, ENT, FLT>
		where DTO : dto.Abstract.BaseDto
		where ENT : BaseEntity, new()
		where FLT : flt.BaseFilter
	{
		public CrudBl(
			ILogger<T> logger,
			HomeAutomationContext context
			) : base(logger, context) { }

		public async Task<DTO> CreateAsnyc(DTO dto)
		{
			return await ExecAsync<DTO>(async () =>
			{
				var ent = await this.DtoToEntAsync(dto);

				await this.context.AddAsync(ent);
				await this.context.SaveChangesAsync();

				return await this.ReadAsync(ent.ID);
			});
		}

		public async Task DeleteAsync(int id)
		{
			await ExecAsync(async () =>
			{
				var ent = await this.LoadEntAsnyc(id);
				if (ent == null)
					throw new Exception($"Entity {this.EntName} with ID {id} not found.");

				this.DbSet().Remove(ent);
				await this.context.SaveChangesAsync();
			});
		}

		public async Task<DTO> UpdateAsync(DTO dto)
		{
			if (!dto.ID.HasValue || dto.ID <= 0)
				throw new ArgumentException("Cannot update DTO with missing ID");

			return await ExecAsync<DTO>(async () =>
			{
				var ent = await this.LoadEntAsnyc(dto.ID.Value);
				if (ent == null)
					throw new Exception($"Entity {this.EntName} with ID {dto.ID} not found.");

				ent = await this.DtoToEntAsync(dto, ent);

				await this.context.SaveChangesAsync();

				return await this.ReadAsync(ent.ID);
			});
		}


		protected Task<ENT> DtoToEntAsync(DTO dto)
		{
			return this.DtoToEntAsync(dto, new ENT());
		}

		protected abstract Task<ENT> DtoToEntAsync(DTO dto, ENT ent);
	}
}
