using DEXRPG.Common.Configuration;
using DEXRPG.WebApi.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DEXRPG.WebApi.Configuration;

public static class GetConfiguration
{
    public record Response(int characterShare);
    
    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("configuration", Handler);
        }
    }

    private static async Task<IResult> Handler([FromServices]IOptions<DExRpgConfiguration> characterConfigurationOptions)
    {
        var response = new Response(int.Parse(characterConfigurationOptions.Value.CharacterShare));
        return Results.Ok(response);
    }
}