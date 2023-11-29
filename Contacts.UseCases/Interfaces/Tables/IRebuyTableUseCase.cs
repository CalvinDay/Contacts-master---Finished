namespace Contacts.UseCases.Interfaces.Tables
{
    public interface IRebuyTableUseCase
    {
        Task ExecuteAsync(int tableId);
    }
}