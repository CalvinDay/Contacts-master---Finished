using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Tables;

namespace Contacts.UseCases.UseCases.Tables
{
    public class AddTableUseCase : IAddTableUseCase
    {
        private readonly ITableRepository tableRepository;

        public AddTableUseCase(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }

        public async Task ExecuteAsync(Table table)
        {
            await tableRepository.AddTableAsync(table);
        }
    }
}
