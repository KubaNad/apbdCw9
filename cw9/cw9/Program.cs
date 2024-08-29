using cw9.Client;
using cw9.ClientTrip;
using cw9.Context;
using cw9.Trip;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Kuba2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Kuba2Connection")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterEndpointsForTrips();
app.RegisterEndpointsForClient();
app.RegisterEndpointsForClientTrips();
    
app.UseHttpsRedirection();

app.Run();

