using Contacts.UseCases.PluginInterfaces;
using Contacts.CoreBusiness;
using Contacts.UseCases.Interfaces.Tables;

namespace Contacts.UseCases.UseCases.Tables
{
    // All the code in this file is included in all platforms.
    public class ViewTablesUseCase : IViewTablesUseCase
    {
        private readonly ITableRepository tableRepository;

        public ViewTablesUseCase(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }

        public async Task<List<Table>> ExecuteAsync(string filterText)
        {
            return await tableRepository.GetTablesAsync(filterText);
        }

    }
}