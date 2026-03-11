using BepopAppServer.API.Middlewares;
using BepopAppServer.Business.Extensions;
using BepopAppServer.DAL.Context;
using BepopAppServer.DAL.Extensions;
using BepopAppServer.Entity.Entities;
using Mapster;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.WithOrigins("http://localhost:4200")
              .AllowCredentials()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// --- MAPSTER DÖNGÜ KORUMASI ---
TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
// ------------------------------

builder.Services.ServicesDalRegistration(builder.Configuration)
                .ServicesBusinessRegistration();

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<AppUser>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddOpenApi();
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<ValidationFilter>();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapIdentityApi<AppUser>();

app.MapControllers();

app.Run();
