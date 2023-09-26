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
      public class UserController
      {
            public int? LoginCheck(string login)
            {
                  if (!string.IsNullOrEmpty(login) && login.Length <= 20 && login.All(x => char.IsLetter(x) || char.IsWhiteSpace(x)))
                  {
                        using (var db = new UserContext())
                        {
                              try
                              {
                                    // поиск юзера и возврат 0, если не null
                                    var user = db.Users.FirstOrDefault(g => g.Nickname.ToLower() == login.ToLower());
                                    if (user != null)
                                    {
                                          return 0;
                                    }
                                    else
                                    {
                                          User userTemp = new User();
                                          userTemp.Nickname = login;
                                          userTemp.Score = 0;
                                          userTemp.Time = 0;
                                          db.Users.Add(userTemp);
                                          db.SaveChanges();
                                          // поиск созданного юзера и возврат его ID, если не null
                                          var newUser = db.Users.FirstOrDefault(g => g.Nickname == userTemp.Nickname);
                                          return newUser?.Id;
                                    }
                              }
                              catch (Exception ex)
                              {
                                    MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    return null;
                              }
                        }
                  }
                  else
                  {
                        MessageBox.Show("Логин должен содержать только латинские буквы и пробелы, длина не более 20 символов", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return null;
                  }
            }

            public User? GetUserInfo(int id)
            {
                  using (var db = new UserContext())
                  {
                        var user = db.Users.FirstOrDefault(g => g.Id == id);
                        if (user != null)
                        {
                              return user;
                        }
                  }
                  return null;
            }

            public bool EditUser(User gamer)
            {
                  if (gamer == null)
                  {
                        MessageBox.Show("User null", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                  }
                  using (var db = new UserContext())
                  {
                        User? temp = new User();
                        try
                        {
                              temp = db.Users.Find(gamer.Id);
                              if (temp != null)
                              {
                                    temp.Nickname = gamer.Nickname;
                                    temp.Score = gamer.Score;
                                    temp.Time = gamer.Time;
                                    db.SaveChanges();
                                    return true;
                              }
                              return false;
                        }
                        catch (Exception ex)
                        {
                              MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                              return false;
                        }
                  }
            }

            public IEnumerable<User?> LeaderBoard(int quantityOfPlayers)
            {
                  if (quantityOfPlayers < 0) { return Enumerable.Empty<User?>(); }
                  //using(var db = new AppContext())
                  //{

                  //}
                  var db = new UserContext(); // с using или dispose IEnumerable не передаётся, выдаёт ошибку: Cannot access a disposed context instance.
                  try
                  {
                        var users = db.Users.OrderByDescending(o => o.Score).Take(quantityOfPlayers).AsEnumerable();
                        //var users = (from g in db.Gamers
                        //             orderby g.Score descending
                        //             select g).Take(quantityOfPlayers).AsEnumerable();
                        return users;
                  }
                  catch (Exception ex)
                  {
                        MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return Enumerable.Empty<User?>();
                  }
            }


            //************************_Асинхронные_методы_************************
            public async ValueTask<int?> LoginCheckAsync(string login)
            {
                  if (!string.IsNullOrEmpty(login) && login.Length <= 20 && login.All(x => char.IsLetter(x) || char.IsWhiteSpace(x)))
                  {
                        //MessageBox.Show("Логин написан верно", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        using (var db = new UserContext())
                        {
                              try
                              {
                                    // поиск юзера и возврат 0, если не null
                                    var user = await db.Users.FirstOrDefaultAsync(g => g.Nickname.ToLower() == login.ToLower());
                                    if (user != null)
                                    {
                                          return 0;
                                    }
                                    else
                                    {
                                          User userTemp = new User();
                                          userTemp.Nickname = login;
                                          userTemp.Score = 0;
                                          userTemp.Time = 0; // 0 будет, когда пересоздам БД с int
                                          await db.Users.AddAsync(userTemp);
                                          await db.SaveChangesAsync();
                                          // поиск созданного юзера и возврат его ID, если не null
                                          var newUser = await db.Users.FirstOrDefaultAsync(g => g.Nickname == userTemp.Nickname);
                                          return newUser?.Id;
                                    }
                              }
                              catch (Exception ex)
                              {
                                    MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    return null;
                              }
                        }
                  }
                  else
                  {
                        MessageBox.Show("Логин должен содержать только латинские буквы и пробелы, длина не более 20 символов", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return null;
                  }
            }

            public async ValueTask<User?> GetUserInfoAsync(int id)
            {
                  // test.Result?.Nickname; // через Result показывает поля объекта
                  using (var db = new UserContext())
                  {
                        //var user = db.Gamers.Where(g => g.Id == id).FirstOrDefault();
                        //var user = await db.Gamers.Where(g => g.Id == id).FirstOrDefault();
                        var user = await db.Users.FirstOrDefaultAsync(g => g.Id == id);
                        if (user != null)
                        {
                              return user;
                        }
                  }
                  return null;
            }

            public async ValueTask<bool> EditUserAsync(User gamer)
            {
                  if (gamer == null)
                  {
                        MessageBox.Show("User null", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                  }
                  using (var db = new UserContext())
                  {
                        User? temp = new User();
                        try
                        {
                              temp = await db.Users.FindAsync(gamer.Id);
                              if (temp != null)
                              {
                                    temp.Nickname = gamer.Nickname;
                                    temp.Score = gamer.Score;
                                    temp.Time = gamer.Time;
                                    await db.SaveChangesAsync();
                                    return true;
                              }
                              return false;
                        }
                        catch (Exception ex)
                        {
                              MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                              return false;
                        }
                  }
            }
      }
}
