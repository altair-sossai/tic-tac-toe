using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe;

namespace TicTacToeApp.Models
{
    public class GameInfo
    {
        public GameInfo(Guid gameId)
        {
            GameId = gameId;
        }

        public Guid GameId { get; }
        public Game Game { get; private set; }
        public HashSet<string> Players { get; } = new HashSet<string>();

        public void AddPlayer(string player)
        {
            if (Players.Count >= 2 || Players.Contains(player))
                return;

            Players.Add(player);

            if (Players.Count != 2)
                return;

            Game = new Game(Players.First(), Players.Last());
        }
    }

    public class GameManager
    {
        private static readonly Dictionary<Guid, GameInfo> Games = new Dictionary<Guid, GameInfo>();

        public static Guid New()
        {
            var gameId = Guid.NewGuid();
            var gameInfo = new GameInfo(gameId);

            Games.Add(gameId, gameInfo);

            return gameId;
        }

        public static GameInfo Find(Guid gameId)
        {
            return !Games.ContainsKey(gameId) ? null : Games[gameId];
        }
    }
}