using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Data;
using VerticalSliceArchitecture.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VerticalSliceSql")));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddFastEndpoints();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFastEndpoints();
app.MapControllers();

 app.Run();
