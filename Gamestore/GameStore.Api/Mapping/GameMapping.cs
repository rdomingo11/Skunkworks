using System;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GameMapping
{
    public static GameSummaryDto ToGameSummaryDto(this Game game) =>
        new(game.Id, game.Name, game.Genre!.Name, game.Price, game.ReleaseDate);

    public static GameDetailsDto ToGameDetailsDto(this Game game) =>
        new(game.Id, game.Name, game.GenreId, game.Price, game.ReleaseDate);

    public static Game ToEntity(this CreateGameDto game) =>
        new()
        {
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

    public static Game ToEntity(this UpdateGameDto game, int id) =>
        new()
        {
            Id = id,
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

    public static void UpdateEntity(this Game game, UpdateGameDto updateGame) =>
        game.Price = updateGame.Price;

}
