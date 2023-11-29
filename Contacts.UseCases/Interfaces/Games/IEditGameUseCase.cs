﻿namespace Contacts.UseCases.Interfaces.Games
{
    public interface IEditGameUseCase
    {
        Task ExecuteAsync(int gameId, CoreBusiness.Game game);
    }
}