using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClikerGame.Data.UserModel;

namespace ClikerGame.Data
{
      public interface IUserController
      {
            public bool EditUser(User gamer);
            public IEnumerable<User?> LeaderBoard(int quantityOfPlayers);
            public User? GetUser(int id);
            public User? GetUser(string userName);

            //************************_Асинхронные_методы_************************
            public ValueTask<bool> EditUserAsync(User gamer);
            public ValueTask<IEnumerable<User?>> LeaderBoardAsync(int quantityOfPlayers);
            public ValueTask<User?> GetUserAsync(int id);
            public ValueTask<User?> GetUserAsync(string userName);
      }
}
