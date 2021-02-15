using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Enums;

namespace TicTacToe.UnitTest
{
    [TestClass]
    public class GameTest
    {
        private const string Player01 = "PLAYER 01";
        private const string Player02 = "PLAYER 02";
        private Game _game;

        [TestInitialize]
        public void Initialize()
        {
            _game = new Game(Player01, Player02);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Invalid_Players_Name()
        {
            _game = new Game(Player01, Player01);
        }

        [TestMethod]
        public void First_Player_Wins_Game_001()
        {
            var positions = new[] {6, 4, 2, 7, 0, 8, 1};

            foreach (var position in positions)
            {
                _game.Play(_game.CurrentPlayer, position);

                Print();

                if (position != positions.Last())
                    Assert.AreEqual(Status.InGame, _game.Status);
            }

            Assert.AreNotEqual(Status.InGame, _game.Status);
            Assert.AreNotEqual(Status.Tied, _game.Status);
        }

        [TestMethod]
        public void First_Player_Wins_Game_002()
        {
            var positions = new[] {6, 4, 0, 8, 3};

            foreach (var position in positions)
            {
                _game.Play(_game.CurrentPlayer, position);

                Print();

                if (position != positions.Last())
                    Assert.AreEqual(Status.InGame, _game.Status);
            }

            Assert.AreNotEqual(Status.InGame, _game.Status);
            Assert.AreNotEqual(Status.Tied, _game.Status);
        }

        [TestMethod]
        public void Second_Player_Wins_Game_001()
        {
            var positions = new[] {6, 2, 4, 0, 8, 1};

            foreach (var position in positions)
            {
                _game.Play(_game.CurrentPlayer, position);

                Print();

                if (position != positions.Last())
                    Assert.AreEqual(Status.InGame, _game.Status);
            }

            Assert.AreNotEqual(Status.InGame, _game.Status);
            Assert.AreNotEqual(Status.Tied, _game.Status);
        }

        [TestMethod]
        public void Tied_Game_001()
        {
            var positions = new[] {6, 2, 8, 0, 4, 7, 1, 5, 3};

            foreach (var position in positions)
            {
                _game.Play(_game.CurrentPlayer, position);

                Print();

                if (position != positions.Last())
                    Assert.AreEqual(Status.InGame, _game.Status);
            }

            Assert.AreEqual(Status.Tied, _game.Status);
        }

        [TestMethod]
        public void Invalid_Player_01()
        {
            var currentPlayer = _game.CurrentPlayer;

            _game.Play("Lorem ipsum", 1);

            Assert.AreEqual(currentPlayer.Name, _game.CurrentPlayer.Name);
        }

        [TestMethod]
        public void Invalid_Player_02()
        {
            var firstPlayer = _game.CurrentPlayer;
            var secondPlayer = _game.OtherPlayer;

            Assert.AreEqual(firstPlayer.Name, _game.CurrentPlayer.Name);

            _game.Play(secondPlayer, 1);

            Assert.AreEqual(firstPlayer.Name, _game.CurrentPlayer.Name);

            _game.Play(firstPlayer, 1);

            Assert.AreEqual(secondPlayer.Name, _game.CurrentPlayer.Name);

            _game.Play(firstPlayer, 2);

            Assert.AreEqual(secondPlayer.Name, _game.CurrentPlayer.Name);
        }

        [TestMethod]
        public void Invalid_Position()
        {
            var currentPlayer = _game.CurrentPlayer;

            _game.Play(_game.CurrentPlayer.Name, -1);

            Assert.AreEqual(currentPlayer.Name, _game.CurrentPlayer.Name);

            _game.Play(_game.CurrentPlayer.Name, 9);

            Assert.AreEqual(currentPlayer.Name, _game.CurrentPlayer.Name);
        }

        [TestMethod]
        public void Position_Already_Occupied()
        {
            var firstPlayer = _game.CurrentPlayer;
            var secondPlayer = _game.OtherPlayer;

            _game.Play(firstPlayer, 1);

            Assert.AreEqual(secondPlayer.Name, _game.CurrentPlayer.Name);

            _game.Play(_game.CurrentPlayer.Name, 1);

            Assert.AreEqual(secondPlayer.Name, _game.CurrentPlayer.Name);
        }

        private void Print()
        {
            Console.WriteLine(_game.Status.ToString());

            for (int i = 0, k = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    switch (i % 2)
                    {
                        case 0 when j % 2 == 0:
                            Console.Write(_game.Hash[k++]);
                            break;

                        case 0 when j % 2 != 0:
                            Console.Write('|');
                            break;

                        default:
                            Console.Write('-');
                            break;
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}