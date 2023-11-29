﻿namespace Contacts.UseCases.Interfaces.Contacts
{
    public interface IViewContactsUseCase
    {
        Task<List<CoreBusiness.Contact>> ExecuteAsync(string filterText);
    }
}