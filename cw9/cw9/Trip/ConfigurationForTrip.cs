namespace cw9.Trip;

public static class ConfigurationForTrip
{
    public static void RegisterEndpointsForTrips(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/trips", async (ITripService tripService, int page = 1, int pageSize = 10) =>
        {
            var (trips, totalTrips) = await tripService.GetTripsAsync(page, pageSize);

            var response = new
            {
                pageNum = page,
                pageSize = pageSize,
                allPages = (int)Math.Ceiling(totalTrips / (double)pageSize),
                trips = trips.Select(t => new
                {
                    t.Name,
                    t.Description,
                    t.DateFrom,
                    t.DateTo,
                    t.MaxPeople,
                    Countries = t.IdCountries.Select(c => new { c.Name }),
                    Clients = t.ClientTrips.Select(ct => new
                        { ct.IdClientNavigation.FirstName, ct.IdClientNavigation.LastName })
                })
            };

            return Results.Ok(response);
        });

    }
}