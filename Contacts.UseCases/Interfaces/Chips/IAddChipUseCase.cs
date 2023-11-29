namespace Contacts.UseCases.Interfaces.Chips
{
    public interface IAddChipUseCase
    {
        Task ExecuteAsync(CoreBusiness.Chip chip);
    }
}