namespace Contacts.UseCases.Interfaces.Tables
{
    public interface IDeleteTableUseCase
    {
        Task ExecuteAsync(int tableId);
    }
}