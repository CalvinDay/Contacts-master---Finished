﻿namespace Contacts.UseCases.Interfaces.Contacts
{
    public interface IEditContactUseCase
    {
        Task ExecuteAsync(int contactId, CoreBusiness.Contact contact);
    }
}