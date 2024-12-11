using AutoMapper;
using BL;
using DAL;

var builder = WebApplication.CreateBuilder(args);

//var port = Environment.GetEnvironmentVariable("PORT") ?? "7180";
//builder.WebHost.UseUrls($"http://*:{port}");

// Add services to the container.
builder.Services.AddDALDependencies(builder.Configuration);
builder.Services.AddBLDependencies();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(VersionDAL), typeof(UserDal), typeof(RepositoryDal), typeof(BranchDal), typeof(MergeDAL));
builder.Services.AddSwaggerGen();

// הוסף שירות CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();
Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// הוסף את השימוש במדיניות CORS
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
