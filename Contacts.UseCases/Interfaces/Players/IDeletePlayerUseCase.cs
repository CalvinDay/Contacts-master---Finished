namespace Contacts.UseCases.Interfaces.Players
{
    public interface IDeletePlayerUseCase
    {
        Task ExecuteAsync(int playerId);
    }
}