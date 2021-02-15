using System;

namespace TicTacToe.Extensions
{
    public static class RandomExtensions
    {
        public static bool NextBool(this Random random, int truePercentage = 50)
        {
            return random.NextDouble() < truePercentage / 100.0;
        }
    }
}