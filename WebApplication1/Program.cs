using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using BL;
using DAL;
using IBL;
using IDAL;

var builder = WebApplication.CreateBuilder(args);

// ׳”׳’׳“׳¨׳× ׳”׳×׳׳•׳×׳•׳× ׳-DAL ׳•-BL
builder.Services.AddDALDependencies();
builder.Services.AddBLDependencies();

// ׳”׳’׳“׳¨׳× DbContext ׳¢׳ Connection String
builder.Services.AddDbContext<RivkiGvirerContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
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
