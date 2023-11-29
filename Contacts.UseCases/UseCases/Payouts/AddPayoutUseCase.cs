using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Payouts;

namespace Contacts.UseCases.UseCases.Payouts
{
    public class AddPayoutUseCase : IAddPayoutUseCase
    {
        private readonly IPayoutRepository payoutRepository;

        public AddPayoutUseCase(IPayoutRepository payoutRepository)
        {
            this.payoutRepository = payoutRepository;
        }

        public async Task ExecuteAsync(Payout payout)
        {
            await payoutRepository.AddPayoutAsync(payout);
        }
    }
}
