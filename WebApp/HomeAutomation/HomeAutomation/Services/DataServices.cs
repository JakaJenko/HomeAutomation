using HomeAutomation.Data.Bl;
using HomeAutomation.Data;
using HomeAutomation.Data.Bl.Abstract;

namespace HomeAutomation.Services
{
	public static class DataServices
	{
		public static void RegisterDataServices(WebApplicationBuilder builder)
		{
			builder.Services.AddScoped <IDbInitializerBl, DbInitializerBl> ();
			builder.Services.AddScoped<ITransactionBl, TransactionBl>();

			builder.Services.AddScoped<ISensorBl, SensorBl>();
			builder.Services.AddScoped<ISensorTypeBl, SensorTypeBl>();
		}
	}
}
