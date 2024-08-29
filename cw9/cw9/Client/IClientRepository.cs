namespace cw9.Client;

public interface IClientRepository
{
    Task<IEnumerable<Models.Client>> GetAllClientsAsync();
    Task<Models.Client?> GetClientByIdAsync(int clientId);
    Task<Models.Client?> GetClientByPeselAsync(string pesel);
    Task AddClientAsync(Models.Client client);
    Task DeleteClientAsync(Models.Client client);
    Task<bool> SaveChangesAsync();
}