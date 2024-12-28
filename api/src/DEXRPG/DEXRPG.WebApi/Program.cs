using DEXRPG.Common;
using DEXRPG.Common.Database.InMemoryDatabase;
using DEXRPG.WebApi.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpoints();
builder.Services.AddDbContext<DbDexRpgContext>(optionsBuilder =>
{
    optionsBuilder.UseInMemoryDatabase("TempDEXRPGDatabase");
});
builder.Services.AddCommonServices();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
else
{
    app.UseHttpsRedirection();
}

app.UseCors(o => o.AllowAnyOrigin());

app.MapEndpoints();


app.Run();