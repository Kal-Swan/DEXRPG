using DEXRPG.Common.Database;
using Microsoft.AspNetCore.Mvc;

namespace DEXRPG.WebApi.Character;

using DEXRPG.WebApi.Endpoints;

public static class CreateCharacter
{
    public record Request(string Name);
    
    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("createCharacter", Handler);
        }
    }

    private static async Task<IResult> Handler([FromBody]Request request, [FromServices]IRepository<Common.Database.Models.Character> repository)
    {
        var errors = Validate(request);

        if (errors.Any())
        {
            return Results.BadRequest(string.Join(",", errors));
        }

        var character = new Common.Database.Models.Character
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        };

        await repository.Create(character);
        return Results.Created();
    }

    private static IEnumerable<string> Validate(Request request)
    {
        if (request.Name == string.Empty)
        {
            yield return "Name is required";
        }
    }
}