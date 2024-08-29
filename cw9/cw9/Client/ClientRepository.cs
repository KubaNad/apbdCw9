using System.Net.Sockets;
using cw9.Context;
using cw9.Models;
using Microsoft.EntityFrameworkCore;

namespace cw9.Client;

public class ClientRepository : IClientRepository
{
    private readonly Kuba2Context _context;

    public ClientRepository(Kuba2Context context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Models.Client>> GetAllClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Models.Client?> GetClientByIdAsync(int clientId)
    {
        return await _context.Clients
            .Where(c => c.IdClient == clientId).SingleAsync();
    }

    public async Task<Models.Client?> GetClientByPeselAsync(string pesel)
    {
        return await _context.Clients.FirstOrDefaultAsync(c => c.Pesel == pesel);
    }

    public async Task AddClientAsync(Models.Client client)
    {
        await _context.Clients.AddAsync(client);
    }

    public async Task DeleteClientAsync(Models.Client client)
    {
        _context.Clients.Remove(client);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
    public async Task<bool> IsClientStoredAsync(int clientId)
    {
        return await _context.Set<Models.ClientTrip>() // Zakładając, że ClientTrip to klasa reprezentująca tabelę Client_Trip
            .AnyAsync(ct => ct.IdClient == clientId);
    }
    
}