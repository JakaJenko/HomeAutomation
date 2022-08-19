using HomeAutomation.Data.Entities.Abstract;
namespace HomeAutomation.Data.Bl.Abstract
{
	public interface IReadBl<DTO, FLT>
		where DTO : dto.Abstract.BaseDto
		where FLT : flt.BaseFilter
	{
		Task<List<DTO>> ListAsync(int skip = 0, int? take = null, FLT? filter = null);
		Task<DTO> ReadAsync(int id);
	}

	public abstract class ReadBl<T, DTO, ENT, FLT> : BaseBl<T>, IReadBl<DTO, FLT>
		where T : ReadBl<T, DTO, ENT, FLT>
		where DTO : dto.Abstract.BaseDto
		where ENT : BaseEntity
		where FLT : flt.BaseFilter
	{
		public ReadBl(
			ILogger<T> logger,
			HomeAutomationContext context
			) : base(logger, context) { }

		public abstract string EntName { get; }

		public async Task<List<DTO>> ListAsync(int skip = 0, int? take = null, FLT? filter = null)
		{
			return await ExecAsync<List<DTO>>(async () =>
			{
				var query = this.OrderListAsync(this.DbSet(), filter);

				if (skip > 0)
					query = query.Skip(skip);

				if (take.HasValue)
					query = query.Take(skip);

				return (await query.ToListAsync())
				.Select(x => this.EntToDtoWithIdAsync(x).Result)
				.ToList();
			});
		}

		public async Task<DTO> ReadAsync(int id)
		{
			return await ExecAsync<DTO>(async () =>
			{
				var ent = await LoadEntAsnyc(id);

				if (ent == null)
					throw new Exception($"{this.EntName} with ID {id} not found.");

				var dto = await this.EntToDtoWithIdAsync(ent);

				return dto;
			});
		}

		protected virtual DbSet<ENT> DbSet()
		{
			return this.context.Set<ENT>();
		}

		protected private async Task<ENT?> LoadEntAsnyc(int id)
		{
			return await this.DbSet().FirstOrDefaultAsync(x => x.ID == id);
		}

		private async Task<DTO> EntToDtoWithIdAsync(ENT ent)
		{
			var dto = await this.EntToDtoAsync(ent);
			dto.ID = ent.ID;

			if (dto is dto.Abstract.VersionedDto versionedDto)
			{
				if (ent is VersionedEntity versionedEntity)
				{
					versionedDto.CreatedOn = versionedEntity.CreatedOn;
					versionedDto.ModifiedOn = versionedEntity.ModifiedOn;
				}
			}

			return dto;
		}

		protected abstract IQueryable<ENT> OrderListAsync(IQueryable<ENT> query, FLT? filter = null);
		protected abstract Task<DTO> EntToDtoAsync(ENT ent);
	}
}
