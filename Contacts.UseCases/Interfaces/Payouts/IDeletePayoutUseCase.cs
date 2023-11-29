namespace Contacts.UseCases.Interfaces.Payouts
{
    public interface IDeletePayoutUseCase
    {
        Task ExecuteAsync(int payoutId);
    }
}