using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Payouts;

namespace Contacts.UseCases.UseCases.Payouts
{
    public class ViewPayoutUseCase : IViewPayoutUseCase
    {
        private readonly IPayoutRepository payoutRepository;

        public ViewPayoutUseCase(IPayoutRepository payoutRepository)
        {
            this.payoutRepository = payoutRepository;
        }

        public async Task<Payout> ExecuteAsync(int payoutId)
        {
            return await payoutRepository.GetPayoutByIdAsync(payoutId);
        }
    }
}
