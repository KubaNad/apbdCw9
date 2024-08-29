using cw9.Context;
using Microsoft.EntityFrameworkCore;

namespace cw9.Trip;

public class TripRepository : ITripRepository
{
    private readonly Kuba2Context _context;

    public TripRepository(Kuba2Context context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Models.Trip>> GetAllTripsAsync(int page, int pageSize)
    {
        return await _context.Trips
            .Include(t => t.ClientTrips)
            .ThenInclude(ct => ct.IdClientNavigation)
            .Include(t => t.IdCountries)
            .OrderByDescending(t => t.DateFrom)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<int> GetTripsCountAsync()
    {
        return await _context.Trips.CountAsync();
    }
    
    
}