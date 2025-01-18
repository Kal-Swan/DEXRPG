using Microsoft.AspNetCore.Mvc;

namespace DEXRPG.WebApi.Character;
using DEXRPG.Common.Database;
using DEXRPG.WebApi.Endpoints;

public static class GetCharacter
{
    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("{id}", Handler);
        }
    }

    private static async Task<IResult> Handler([FromRoute]Guid id, [FromServices]IRepository<Common.Database.Models.Character> repository)
    {
        var character = await repository.GetById(id);
        return Results.Ok(character);
    }
}