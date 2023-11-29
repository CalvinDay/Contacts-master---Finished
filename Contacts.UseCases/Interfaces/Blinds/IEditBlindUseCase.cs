namespace Contacts.UseCases.Interfaces.Blinds
{
    public interface IEditBlindUseCase
    {
        Task ExecuteAsync(int blindId, CoreBusiness.Blind blind);
    }
}