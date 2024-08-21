using DataAccessLayer.Repositories;
using MyWebApplication.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BlogContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IWeatherForecastRepository, WeatherForecastRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*app.UseAuthentication();//allways first
app.UseAuthorization();//allways second*/

/*app.UseExceptionHandler();*/
app.UseMiddleware<RequestLoggingMiddleware>();
app.MapControllers();


app.Run();
