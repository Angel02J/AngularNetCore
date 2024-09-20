using Microsoft.EntityFrameworkCore;
using PeliculasAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<AplicationDbContext>(options => options.UseSqlServer("name=DefaultConnection"));

builder.Services.AddOutputCache(option =>
{
    option.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(30);
});

var origenesPermitidos = builder.Configuration.GetValue<string>("origenesPermitidos")!.Split(",");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(optionsCors =>
    {
        optionsCors.WithOrigins(origenesPermitidos)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("cantidad-total-registros");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseOutputCache();

app.UseAuthorization();

app.MapControllers();

app.Run();
