namespace Contacts.UseCases.Interfaces.Players
{
    public interface IAddPlayerUseCase
    {
        Task ExecuteAsync(CoreBusiness.Player player);
    }
}