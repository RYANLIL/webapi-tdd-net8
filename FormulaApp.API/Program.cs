using FormulaApp.API.Configuration;
using FormulaApp.API.Services;
using FormulaApp.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//API Services
builder.Services.AddScoped<IFanService, FanService>();
builder.Services.AddHttpClient<IFanService, FanService>();
//Allows injection of url string
builder.Services.Configure<ApiServiceConfig>(builder.Configuration.GetSection("ApiServiceConfig"));


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

app.Run();
