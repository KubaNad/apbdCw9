namespace cw9.Client;

public static class ConfigurationForClient
{
    public static void RegisterEndpointsForClient(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/clients/{idClient}", async (int idClient, IClientService clientService) => 
        {
            var result = await clientService.DeleteClientAsync(idClient);
            if (!result)
            {
                return Results.BadRequest("Cannot delete client which is not exist or with assigned trips.");
            }

            return Results.NoContent();
        });

    }
}