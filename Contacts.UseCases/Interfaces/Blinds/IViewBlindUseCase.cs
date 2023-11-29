namespace Contacts.UseCases.Interfaces.Blinds
{
    public interface IViewBlindUseCase
    {
        Task<CoreBusiness.Blind> ExecuteAsync(int blindId);
    }
}