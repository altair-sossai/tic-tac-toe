using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Extensions
{
    public static class HashExtensions
    {
        public static bool Full(this IEnumerable<char> hash)
        {
            return hash.All(c => c != ' ');
        }
    }
}