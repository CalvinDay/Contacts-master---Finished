using Contacts.UseCases.Interfaces.Payouts;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases.UseCases.Payouts
{
    public class DeletePayoutUseCase : IDeletePayoutUseCase
    {
        private readonly IPayoutRepository payoutRepository;

        public DeletePayoutUseCase(IPayoutRepository payoutRepository)
        {
            this.payoutRepository = payoutRepository;
        }

        public async Task ExecuteAsync(int payoutId)
        {
            await payoutRepository.DeletePayoutAsync(payoutId);
        }
    }
}
