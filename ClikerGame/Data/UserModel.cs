using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClikerGame.Data
{
      public class UserModel
      {
            public class User
            {
                  [Key]
                  public int Id { get; set; }
                  public string Nickname { get; set; }
                  public int Score { get; set; }
                  public int Time { get; set; }
                  public int QuantityOfModifiers { get; set; }
                  public List<Modifier> Modifiers { get; set; } = new List<Modifier>();
            }
            public class Modifier
            {
                  [Key]
                  public int Id { get; set; }
                  public string? Name { get; set; }
                  public int Price { get; set; }
                  public int Modificator { get; set; }
                  public List<User> Gamers { get; set; } = new List<User>();
            }
      }
}
