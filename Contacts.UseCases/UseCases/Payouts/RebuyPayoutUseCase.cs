using Contacts.UseCases.Interfaces.Payouts;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases.UseCases.Payouts
{
    public class RebuyPayoutUseCase : IRebuyPayoutUseCase
    {
        private readonly IPayoutRepository payoutRepository;

        public RebuyPayoutUseCase(IPayoutRepository payoutRepository)
        {
            this.payoutRepository = payoutRepository;
        }

        public async Task ExecuteAsync(int payoutId)
        {
            await payoutRepository.RebuyPayoutAsync(payoutId);
        }
    }
}
