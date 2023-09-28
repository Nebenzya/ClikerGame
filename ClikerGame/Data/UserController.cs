using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static ClikerGame.Data.UserModel;

namespace ClikerGame.Data
{
      public class UserController : IUserController
      {
            private UserContext _db;
            public UserController()
            {
                  _db = new UserContext();
            }
            private bool LoginCheck(string login)
            {
                  if (!string.IsNullOrEmpty(login) && login.Length <= 20 && login.All(x => char.IsLetter(x) || char.IsWhiteSpace(x)))
                  {
                        return true;
                  }
                  else
                  {
                        //throw new ArgumentException("Логин должен содержать только латинские буквы и пробелы, длина не более 20 символов");
                        return false;
                  }
            }
            public bool EditUser(User user)
            {
                  if (user == null)
                  {
                        throw new ArgumentException("User null");
                  }
                  User? temp = new User();
                  temp = _db.Users.Find(user.Id);
                  if (temp != null)
                  {
                        temp.Nickname = user.Nickname;
                        temp.Score = user.Score;
                        temp.Time = user.Time;
                        _db.SaveChanges();
                        return true;
                  }
                  return false;
            }

            public IEnumerable<User?> LeaderBoard(int quantityOfPlayers)
            {
                  if (quantityOfPlayers < 0)
                        throw new ArgumentException("quantityOfPlayers должно быть больше нуля");
                  //using (var db = new UserContext())
                  return _db.Users.OrderByDescending(o => o.Score).Take(quantityOfPlayers).AsEnumerable();
            }

            public User? GetUser(int id)
            {
                  var user = _db.Users.FirstOrDefault(g => g.Id == id);
                  if (user != null)
                  {
                        return user;
                  }
                  return null;
            }
            public User? GetUser(string userName)
            {
                  if(LoginCheck(userName))
                  {
                        // поиск юзера и возврат его, если не null
                        var user = _db.Users.FirstOrDefault(g => g.Nickname.ToLower() == userName.ToLower());
                        if (user != null)
                        {
                              return user;
                        }
                        else
                        {
                              User userTemp = new User();
                              userTemp.Nickname = userName;
                              userTemp.Score = 0;
                              userTemp.Time = 0;
                              _db.Users.Add(userTemp);
                              _db.SaveChanges();
                              // поиск созданного юзера и возврат его, если не null
                              var newUser = _db.Users.FirstOrDefault(g => g.Nickname == userTemp.Nickname);
                              return newUser;
                        }
                  }
                  else
                  {
                        return null;
                  }              
            }

            //************************_Асинхронные_методы_************************
            public async ValueTask<bool> EditUserAsync(User gamer)
            {
                  return await Task.Run(() => EditUser(gamer));
            }
            public async ValueTask<IEnumerable<User?>> LeaderBoardAsync(int quantityOfPlayers)
            {
                  return await Task.Run(() => LeaderBoard(quantityOfPlayers));
            }
            public async ValueTask<User?> GetUserAsync(int id)
            {
                  return await Task.Run(() => GetUser(id));
            }
            public async ValueTask<User?> GetUserAsync(string userName)
            {
                  return await Task.Run(() => GetUser(userName));
            }
            //********************************************************************



            //private async ValueTask<bool> LoginCheckAsync(string login)
            //{
            //      return await Task.Run(() => LoginCheck(login));
            //}

            //public async ValueTask<int?> LoginCheckAsync(string login)
            //{
            //      if (!string.IsNullOrEmpty(login) && login.Length <= 20 && login.All(x => char.IsLetter(x) || char.IsWhiteSpace(x)))
            //      {
            //            //MessageBox.Show("Логин написан верно", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            //            using (var db = new UserContext())
            //            {
            //                  try
            //                  {
            //                        // поиск юзера и возврат 0, если не null
            //                        var user = await db.Users.FirstOrDefaultAsync(g => g.Nickname.ToLower() == login.ToLower());
            //                        if (user != null)
            //                        {
            //                              return 0;
            //                        }
            //                        else
            //                        {
            //                              User userTemp = new User();
            //                              userTemp.Nickname = login;
            //                              userTemp.Score = 0;
            //                              userTemp.Time = 0; // 0 будет, когда пересоздам БД с int
            //                              await db.Users.AddAsync(userTemp);
            //                              await db.SaveChangesAsync();
            //                              // поиск созданного юзера и возврат его ID, если не null
            //                              var newUser = await db.Users.FirstOrDefaultAsync(g => g.Nickname == userTemp.Nickname);
            //                              return newUser?.Id;
            //                        }
            //                  }
            //                  catch (Exception ex)
            //                  {
            //                        MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            //                        return null;
            //                  }
            //            }
            //      }
            //      else
            //      {
            //            MessageBox.Show("Логин должен содержать только латинские буквы и пробелы, длина не более 20 символов", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            //            return null;
            //      }
            //}

            //public async ValueTask<User?> GetUserInfoAsync(int id)
            //{
            //      // test.Result?.Nickname; // через Result показывает поля объекта
            //      using (var db = new UserContext())
            //      {
            //            //var user = db.Gamers.Where(g => g.Id == id).FirstOrDefault();
            //            //var user = await db.Gamers.Where(g => g.Id == id).FirstOrDefault();
            //            var user = await db.Users.FirstOrDefaultAsync(g => g.Id == id);
            //            if (user != null)
            //            {
            //                  return user;
            //            }
            //      }
            //      return null;
            //}

            //public async ValueTask<bool> EditUserAsync(User gamer)
            //{
            //      if (gamer == null)
            //      {
            //            MessageBox.Show("User null", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            //            return false;
            //      }
            //      using (var db = new UserContext())
            //      {
            //            User? temp = new User();
            //            try
            //            {
            //                  temp = await db.Users.FindAsync(gamer.Id);
            //                  if (temp != null)
            //                  {
            //                        temp.Nickname = gamer.Nickname;
            //                        temp.Score = gamer.Score;
            //                        temp.Time = gamer.Time;
            //                        await db.SaveChangesAsync();
            //                        return true;
            //                  }
            //                  return false;
            //            }
            //            catch (Exception ex)
            //            {
            //                  MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            //                  return false;
            //            }
            //      }
            //}
      }
}