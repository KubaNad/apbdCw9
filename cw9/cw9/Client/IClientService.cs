namespace cw9.Client;

public interface IClientService
{
    Task<bool> DeleteClientAsync(int clientId);
    Task<bool> AssignClientToTripAsync(Models.Client client, int tripId, DateTime? paymentDate);
}