namespace cw9.Trip;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;

    public TripService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task<(IEnumerable<Models.Trip>, int)> GetTripsAsync(int page, int pageSize)
    {
        var trips = await _tripRepository.GetAllTripsAsync(page, pageSize);
        var totalTrips = await _tripRepository.GetTripsCountAsync();
        return (trips, totalTrips);
    }
}