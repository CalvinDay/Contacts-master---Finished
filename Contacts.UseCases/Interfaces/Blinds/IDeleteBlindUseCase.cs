namespace Contacts.UseCases.Interfaces.Blinds
{
    public interface IDeleteBlindUseCase
    {
        Task ExecuteAsync(int blindId);
    }
}