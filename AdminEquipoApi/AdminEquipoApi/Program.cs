using AdminEquipoApi;
using AdminEquipoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AdminEquipoApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ADMINEQUIPOSDbContext>(option => option.UseSqlServer(builder.Configuration
    .GetConnectionString("cadenaSQL")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tu API", Version = "v1" });

    // Configura la ruta base
    c.DocumentFilter<BasePathDocumentFilter>("api/controller");
});
builder.Services.AddScoped<ComunaService>();
builder.Services.AddScoped<OficinaService>();
builder.Services.AddScoped<AplicacionService>();
builder.Services.AddScoped<DispositivoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ADMINEQUIPOSDbContext>();
    dbContext.Database.Migrate();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
