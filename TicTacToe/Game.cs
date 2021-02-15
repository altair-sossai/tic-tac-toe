using System;
using TicTacToe.Enums;
using TicTacToe.Extensions;

namespace TicTacToe
{
    public class Game
    {
        private const char Empty = ' ';

        public Game(string player1, string player2)
        {
            if (player1 == player2)
                throw new InvalidOperationException();

            Player1 = Player.Player1(player1);
            Player2 = Player.Player2(player2);

            InitializeHash();
            SelectFirstPlayer();
        }

        public Status Status { get; private set; } = Status.InGame;
        public char[] Hash { get; } = new char[9];
        public Player CurrentPlayer { get; private set; }
        public Player OtherPlayer => CurrentPlayer.Name == Player1.Name ? Player2 : Player1;
        public Player Player1 { get; }
        public Player Player2 { get; }

        private void InitializeHash()
        {
            for (var i = 0; i < 9; i++)
                Hash[i] = Empty;
        }

        private void SelectFirstPlayer()
        {
            var random = new Random();
            var firstPlayer = random.NextBool() ? Player1 : Player2;

            CurrentPlayer = firstPlayer;
        }

        public void Play(Player player, int position)
        {
            Play(player.Name, position);
        }

        public void Play(string player, int position)
        {
            if (CurrentPlayer.Name != player)
                return;

            if (position < 0 || position >= 9)
                return;

            if (Hash[position] != Empty)
                return;

            Hash[position] = CurrentPlayer.Simbol;

            UpdateStatus();
            SwitchCurrentPlayer();
        }

        private void UpdateStatus()
        {
            if (CurrentPlayer.Won(Hash))
                Status = CurrentPlayer.Name == Player1.Name ? Status.Play1Won : Status.Play2Won;

            else if (Hash.Full())
                Status = Status.Tied;
        }

        private void SwitchCurrentPlayer()
        {
            if (Status != Status.InGame)
                return;

            CurrentPlayer = OtherPlayer;
        }
    }
}