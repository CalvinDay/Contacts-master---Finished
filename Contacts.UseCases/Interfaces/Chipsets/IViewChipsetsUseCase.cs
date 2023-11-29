namespace Contacts.UseCases.Interfaces.Chipsets
{
    public interface IViewChipsetsUseCase
    {
        Task<List<CoreBusiness.Chipset>> ExecuteAsync(string filterText);
    }
}