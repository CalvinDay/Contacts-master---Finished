using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Tables;

namespace Contacts.UseCases.UseCases.Tables
{
    public class ViewTableUseCase : IViewTableUseCase
    {
        private readonly ITableRepository tableRepository;

        public ViewTableUseCase(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }

        public async Task<Table> ExecuteAsync(int tableId)
        {
            return await tableRepository.GetTableByIdAsync(tableId);
        }
    }
}
