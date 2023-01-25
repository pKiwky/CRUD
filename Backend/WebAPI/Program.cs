using Application;
using Infrastructure;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(m => m.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();