﻿namespace Contacts.UseCases.Interfaces.Contacts
{
    public interface IAddContactUseCase
    {
        Task ExecuteAsync(CoreBusiness.Contact contact);
    }
}