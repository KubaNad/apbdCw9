namespace cw9.Trip;

public interface ITripRepository
{
    Task<IEnumerable<Models.Trip>> GetAllTripsAsync(int page, int pageSize);
    Task<Models.Trip?> GetTripByIdAsync(int tripId);
    Task<int> GetTripsCountAsync();
}