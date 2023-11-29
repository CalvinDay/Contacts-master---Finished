namespace Contacts.UseCases.Interfaces.Payouts
{
    public interface IRebuyPayoutUseCase
    {
        Task ExecuteAsync(int payoutId);
    }
}