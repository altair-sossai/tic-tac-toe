using System;

namespace TicTacToeApp.Hubs.Commands
{
    public class PlayCommand
    {
        public string GameId { get; set; }
        public int Position { get; set; }
    }
}