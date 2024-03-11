//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


using Microsoft.OpenApi.Writers;
using Movies.Infrastructure.Data;

namespace Movies.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host=CreateHostBuilder(args).Build();
            await CreateAndSeedDb(host);
            host.Run();
        }

        private static async Task CreateAndSeedDb(IHost host)
        {
            using(var scope=host.Services.CreateScope())
            {
                var services=scope.ServiceProvider;
                var loggerFactory=services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var movieContext=services.GetRequiredService<MovieContext>();
                    await MovieContextSeed.SeedAsync(movieContext, loggerFactory);

                }
                catch(Exception ex) 
                {
                    var logger=loggerFactory.CreateLogger<Program>();
                    logger.LogError($"Exception Occurred In API: {ex.Message}");
                }
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
         => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
