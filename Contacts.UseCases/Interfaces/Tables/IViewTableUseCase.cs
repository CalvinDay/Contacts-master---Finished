namespace Contacts.UseCases.Interfaces.Tables
{
    public interface IViewTableUseCase
    {
        Task<CoreBusiness.Table> ExecuteAsync(int tableId);
    }
}