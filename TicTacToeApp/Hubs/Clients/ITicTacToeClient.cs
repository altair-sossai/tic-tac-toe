using System.Threading.Tasks;
using TicTacToeApp.Models;

namespace TicTacToeApp.Hubs.Clients
{
    public interface ITicTacToeClient
    {
        Task Update(GameInfo gameInfo);
    }
}