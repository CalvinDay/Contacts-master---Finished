namespace Contacts.UseCases.Interfaces.Payouts
{
    public interface IAddPayoutUseCase
    {
        Task ExecuteAsync(CoreBusiness.Payout payout);
    }
}