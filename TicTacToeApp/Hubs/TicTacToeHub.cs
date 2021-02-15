using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TicTacToeApp.Hubs.Clients;
using TicTacToeApp.Hubs.Commands;
using TicTacToeApp.Models;

namespace TicTacToeApp.Hubs
{
    public class TicTacToeHub : Hub<ITicTacToeClient>
    {
        public async Task Join(Guid gameId)
        {
            var gameInfo = GameManager.Find(gameId);
            if (gameInfo == null)
                throw new InvalidOperationException();

            gameInfo.AddPlayer(Context.ConnectionId);

            await Clients.Clients(gameInfo.Players).Update(gameInfo);
        }

        public async Task Play(PlayCommand command)
        {
            var gameId = new Guid(command.GameId);
            var gameInfo = GameManager.Find(gameId);
            if (gameInfo == null)
                throw new InvalidOperationException();

            var game = gameInfo.Game;
            
            game.Play(Context.ConnectionId, command.Position);

            await Clients.Clients(gameInfo.Players).Update(gameInfo);
        }
    }
}