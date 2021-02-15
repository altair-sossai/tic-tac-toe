using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public struct Path
    {
        private static readonly Path[] Paths =
        {
            new Path {_frontDoors = new[] {0, 3, 6}, _step = 1},
            new Path {_frontDoors = new[] {0, 1, 2}, _step = 3},
            new Path {_frontDoors = new[] {0}, _step = 4},
            new Path {_frontDoors = new[] {2}, _step = 2}
        };

        private int[] _frontDoors;
        private int _step;

        public static bool CompletedSomePath(char[] hash, Player currentPlayer)
        {
            return Paths.Any(p => p.Won(hash, currentPlayer));
        }

        private bool Won(IReadOnlyList<char> hash, Player currentPlayer)
        {
            foreach (var start in _frontDoors)
            {
                var won = true;

                for (int i = start, j = 0; won && j < 3; i += _step, j++)
                    won &= hash[i] == currentPlayer.Simbol;

                if (won)
                    return true;
            }

            return false;
        }
    }
}