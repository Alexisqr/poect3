using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Data;
using System.Data.SqlClient;

using ShelterEF.DAL.Repositories;
using ShelterDAL.Models;
using ShelterBLL.Services;

using Microsoft.EntityFrameworkCore;
using ShelterDAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
//Connection for EF database + DbContext

// Add services to the container.
//builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
//builder.Configuration.AddJsonFile("appsetings.json", optional: false, reloadOnChange: true);
//builder.Configuration.AddJsonFile($"appsetings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AnShelterIdenContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("SqlConnection");
    //options.UseSqlServer(connectionString);
});
// Connection/Transaction for ADO.NET/DAPPER database

builder.Services.AddScoped((s) => new SqlConnection(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddScoped<IDbTransaction>(s =>
{
    SqlConnection conn = s.GetRequiredService<SqlConnection>();
    conn.Open();
    return conn.BeginTransaction();
});
//Connection for EF database + DbContext
builder.Services.AddScoped<IUnitOfWorks, UnitOfWorks>();

builder.Services.AddScoped<IGoodRepository, GoodRepository>();
builder.Services.AddScoped<IGoodRepository, GoodRepository>();
// Dependendency Injection for Repositories/UOW from EF DAL


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}

    ).AddJwtBearer(x => {
        x.TokenValidationParameters = new TokenValidationParameters
        {

        };
    });

var app = builder.Build();

//////////////////////////////////////////
// MIDDLEWARE -  ŒÕ¬≈™– Œ¡–Œ¡ » «¿œ»“”
// Configure the HTTP request pipeline.
//////////////////////////////////////////


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication( );
app.UseAuthorization();

app.MapControllers();

app.Run();
