using Microsoft.EntityFrameworkCore;
using SampleWebAPi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//here i will add the DBContext class as well so that my aplication will be able to use its services as well
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//above in the UseSQLServer() method its very important to also add the databse connection string so that a proper connection is built and everything functions properly
//after adding important services in program.cs file,run the migrations for the databse
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
