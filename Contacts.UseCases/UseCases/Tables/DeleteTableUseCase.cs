using Contacts.UseCases.Interfaces.Tables;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases.UseCases.Tables
{
    public class DeleteTableUseCase : IDeleteTableUseCase
    {
        private readonly ITableRepository tableRepository;

        public DeleteTableUseCase(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }

        public async Task ExecuteAsync(int tableId)
        {
            await tableRepository.DeleteTableAsync(tableId);
        }
    }
}
