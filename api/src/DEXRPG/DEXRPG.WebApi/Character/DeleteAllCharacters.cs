namespace DEXRPG.WebApi.Character;
using DEXRPG.Common.Database;
using Microsoft.AspNetCore.Mvc;
using DEXRPG.WebApi.Endpoints;

public static class DeleteAllCharacters
{
    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("deleteAllCharacters", Handler);
        }
    }

    private static async Task<IResult> Handler([FromServices]IRepository<Common.Database.Models.Character> repository)
    {
        var characters = await repository.GetMany(character => true);
        var characterIds = characters.Select(x => x.Id).ToList();
        await repository.DeleteMany(character => characterIds.Contains(character.Id));
        return Results.Ok();
    }
}