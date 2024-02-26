using Amazon;
using Amazon.Util;
using HelloWorld.Data;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = builder.Configuration.GetConnectionString("DefaultConnection");


//var pwd = Amazon.RDS.Util.RDSAuthTokenGenerator.GenerateAuthToken(RegionEndpoint.CACentral1, Environment.GetEnvironmentVariable("BD_ENDPOINT"), 3306, "mysql");
builder.Services.AddDbContext<ApiDbContext>(options => options.UseMySql(conn,ServerVersion.AutoDetect(conn)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

//builder.Services.AddHealthChecksUI().AddInMemoryStorage().Services.AddHealthChecks().AddCheck<RandomHealthCheck>("random").;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/healthcheck");
//app
//            .UseRouting()
//            .UseEndpoints(config =>
//            {
//                config.MapHealthChecks("healthz", new HealthCheckOptions
//                {
//                    Predicate = _ => true,
//                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//                });
//                config.MapHealthChecksUI();
//                config.MapDefaultControllerRoute();
//            });

app.Run();

//public class RandomHealthCheck : IHealthCheck
//{
//    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
//    {
//        if (DateTime.UtcNow.Minute % 2 == 0)
//        {
//            return Task.FromResult(HealthCheckResult.Healthy());
//        }

//        return Task.FromResult(HealthCheckResult.Unhealthy(description: "failed"));
//    }
//}