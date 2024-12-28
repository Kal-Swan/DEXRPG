using Microsoft.AspNetCore.Mvc;

namespace DEXRPG.WebApi.Character;
using DEXRPG.Common.Database;
using DEXRPG.WebApi.Endpoints;

public static class GetAllCharacters
{
    public record Response(IResult Result);
    
    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("GetAllCharacters", Handler);
        }
    }

    private static async Task<IResult> Handler([FromServices]IRepository<Common.Database.Models.Character> repository)
    {
        var characters = await repository.GetMany(character => true);
        return Results.Ok(characters);
    }
}