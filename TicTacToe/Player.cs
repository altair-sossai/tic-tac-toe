namespace TicTacToe
{
    public class Player
    {
        public string Name { get; private set; }
        public char Simbol { get; private set; }

        public static Player Player1(string name)
        {
            return new Player {Name = name, Simbol = 'X'};
        }

        public static Player Player2(string name)
        {
            return new Player {Name = name, Simbol = 'O'};
        }

        public bool Won(char[] hash)
        {
            return Path.CompletedSomePath(hash, this);
        }
    }
}