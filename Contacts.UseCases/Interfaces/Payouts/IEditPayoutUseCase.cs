namespace Contacts.UseCases.Interfaces.Payouts
{
    public interface IEditPayoutUseCase
    {
        Task ExecuteAsync(int payoutId, CoreBusiness.Payout payout);
    }
}