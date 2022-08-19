using HomeAutomation.Data.Entities;
using HomeAutomation.Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HomeAutomation.Data
{
	public partial class HomeAutomationContext : DbContext
	{
		public HomeAutomationContext(DbContextOptions<HomeAutomationContext> options)
			: base(options) { }

		internal virtual DbSet<Location> Locations { get; set; } = null!;
		internal virtual DbSet<Measurement> Measurements { get; set; } = null!;
		internal virtual DbSet<Sensor> Sensors { get; set; } = null!;
		internal virtual DbSet<SensorType> SensorTypes { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			OnSaveChanges();
			return base.SaveChangesAsync(cancellationToken);
		}

		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
		{
			OnSaveChanges();
			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		private void OnSaveChanges()
		{
			var now = DateTime.UtcNow;

			foreach (var ent in ChangeTracker.Entries())
			{
				if (ent.Entity is VersionedEntity versionedEntity)
				{
					switch (ent.State)
					{
						case EntityState.Added:
							{
								versionedEntity.CreatedOn = now;
								versionedEntity.ModifiedOn = now;
								break;
							}
						case EntityState.Modified:
							{
								versionedEntity.ModifiedOn = now;
								ent.Property("CreatedOn").IsModified = false;
								break;
							}
					}
				}
			}
		}
	}
}
