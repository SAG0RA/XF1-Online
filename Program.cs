using XFIA_API;
using XFIA_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySQLConnectionConfig = new MySQLConfiguration(builder.Configuration.GetConnectionString(""));

builder.Services.AddSingleton(mySQLConnectionConfig);
builder.Services.AddScoped<JugadorI, JugadorR>();
builder.Services.AddScoped<EquipoI, EquipoR>();
builder.Services.AddScoped<CampeonatoI, CampeonatoR>();
builder.Services.AddScoped<CarreraI, CarreraR>();
builder.Services.AddScoped<EscuderiaI, EscuderiaR>();
builder.Services.AddScoped<PilotoI, PilotoR>();
builder.Services.AddScoped<EquipoPilotoI, EquipoPilotoR>();

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
