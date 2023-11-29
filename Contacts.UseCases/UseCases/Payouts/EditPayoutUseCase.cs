using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Payouts;

namespace Contacts.UseCases.UseCases.Payouts
{
    public class EditPayoutUseCase : IEditPayoutUseCase
    {
        private readonly IPayoutRepository payoutRepository;

        public EditPayoutUseCase(IPayoutRepository payoutRepository)
        {
            this.payoutRepository = payoutRepository;
        }

        public async Task ExecuteAsync(int payoutId, Payout payout)
        {
            await payoutRepository.UpdatePayoutAsync(payoutId, payout);
        }
    }
}
