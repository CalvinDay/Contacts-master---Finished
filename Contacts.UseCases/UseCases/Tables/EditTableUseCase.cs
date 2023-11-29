
using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Tables;

namespace Contacts.UseCases.UseCases.Tables
{
    public class EditTableUseCase : IEditTableUseCase
    {
        private readonly ITableRepository tableRepository;

        public EditTableUseCase(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }

        public async Task ExecuteAsync(int tableId, Table table)
        {
            await tableRepository.UpdateTableAsync(tableId, table);
        }
    }
}
