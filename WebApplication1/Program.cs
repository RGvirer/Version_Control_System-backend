using Microsoft.EntityFrameworkCore;
using IBL;
using DAL.Models;
using Accessories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RivkiGvirerContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependency();
//שולח לפונקציה חיצונית שמטפלת בכל ההפניות
Accessories.AddDependencies.AddDependency(builder.Services);

//builder.Services.AddScoped(typeof(IBL.IObjectBL), typeof(BL.UserServices));
//builder.Services.AddScoped(typeof(IBL.IObjectBL), typeof(BL.DepartmentServices));
//builder.Services.AddScoped(typeof(IBL.IObjectBL), typeof(BL.PatientsServices));

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
