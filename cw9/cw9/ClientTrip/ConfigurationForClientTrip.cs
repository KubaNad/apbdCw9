using cw9.Client;
using cw9.Trip;

namespace cw9.ClientTrip;

public static class ConfigurationForClientTrip
{
    public static void RegisterEndpointsForClientTrips(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/tripclients/trips/{idTrip}/clients", async (int idTrip, ClientTrip clientTrip, IClientService clientService) => 
        {
            var client = new Models.Client
            {
                FirstName = clientTrip.FirstName,
                LastName = clientTrip.LastName,
                Email = clientTrip.Email,
                Telephone = clientTrip.Telephone,
                Pesel = clientTrip.Pesel
            };

            var result = await clientService.AssignClientToTripAsync(client, idTrip, clientTrip.PaymentDate);
            if (!result)
            {
                return Results.BadRequest("Failed to assign client to trip.");
            }

            return Results.Ok();
        }).WithName("AssignClientToTrip");
        
    }
}