namespace cw9.Trip;

public interface ITripService
{
    Task<(IEnumerable<Models.Trip>, int)> GetTripsAsync(int page, int pageSize);
}