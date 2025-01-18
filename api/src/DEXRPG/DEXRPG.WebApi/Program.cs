using Azure.Identity;
using DEXRPG.Common;
using DEXRPG.Common.Configuration;
using DEXRPG.Common.Database.InMemoryDatabase;
using DEXRPG.WebApi.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpoints();
builder.Services.AddDbContext<DbDexRpgContext>(optionsBuilder =>
{
    optionsBuilder.UseInMemoryDatabase("TempDEXRPGDatabase");
});
builder.Services.AddCommonServices();

var appConfiguration = builder.Configuration.GetSection(AppConfiguration.Name).Get<AppConfiguration>();

builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(new Uri(appConfiguration.Endpoint), new DefaultAzureCredential(new DefaultAzureCredentialOptions
        {
            ExcludeSharedTokenCacheCredential = true,
            ExcludeVisualStudioCredential = true,
        }))
        .Select(KeyFilter.Any, LabelFilter.Null)
        .Select(KeyFilter.Any, builder.Environment.EnvironmentName);
});

builder.Services.Configure<DExRpgConfiguration>(builder.Configuration.GetSection(DExRpgConfiguration.Name));
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
else
{
    app.UseHttpsRedirection();
}

app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapEndpoints();


app.Run();