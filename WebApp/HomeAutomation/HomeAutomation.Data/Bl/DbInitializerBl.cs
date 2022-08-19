using HomeAutomation.Data.Bl.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomation.Data.Bl
{
	public interface IDbInitializerBl
	{
		Task InitializeAsync();
		void DropDb();
	}

	public class DbInitializerBl : BaseBl<DbInitializerBl>, IDbInitializerBl
	{
		public DbInitializerBl(
			ILogger<DbInitializerBl> logger,
			HomeAutomationContext context
			) : base(logger, context)
		{ }

		public async Task InitializeAsync()
		{
			bool recreateDb = false;

			if (recreateDb)
			{
				DropDb();
			}

			if (recreateDb)
			{
				this.logger.LogInformation("Creating database.");
				this.context.Database.EnsureCreated();
				await this.InitDataAsync();
			}
		}

		public void DropDb()
		{
			this.logger.LogInformation("Dropping database.");
			this.context.Database.EnsureDeleted();
		}

		private async Task InitDataAsync()
		{
			#region Locations
			await this.context.Locations.AddAsync(new Entities.Location
			{
				Name = "LIVING_ROOM",
				Description = "Living room"
			});

			await this.context.Locations.AddAsync(new Entities.Location
			{
				Name = "KITCHEN",
				Description = "Kitchen"
			});

			await this.context.Locations.AddAsync(new Entities.Location
			{
				Name = "HALLWAY",
				Description = "Hallway"
			});

			await this.context.Locations.AddAsync(new Entities.Location
			{
				Name = "BEDROOM",
				Description = "Bedroom"
			});

			await this.context.Locations.AddAsync(new Entities.Location
			{
				Name = "OFFICE",
				Description = "Office"
			});

			await this.context.Locations.AddAsync(new Entities.Location
			{
				Name = "BALCONY",
				Description = "Balcony"
			});

			await this.context.Locations.AddAsync(new Entities.Location
			{
				Name = "TOILET",
				Description = "Toilet"
			});

			await this.context.Locations.AddAsync(new Entities.Location
			{
				Name = "BATHROOM",
				Description = "Bathroom"
			});

			await this.context.SaveChangesAsync();

			#endregion

			#region SensorType
			await this.context.SensorTypes.AddAsync(new Entities.SensorType
			{
				Name = "WATER_LEAKAGE",
				Description = "Water leakage"
			});

			await this.context.SensorTypes.AddAsync(new Entities.SensorType
			{
				Name = "ROOM_AIR",
				Description = "Room air"
			});

			await this.context.SensorTypes.AddAsync(new Entities.SensorType
			{
				Name = "OUTSIDE_AIR",
				Description = "Outside air"
			});

			await this.context.SaveChangesAsync();
			#endregion
		}
	}
}
