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
                  public long Score { get; set; }
                  public int Time { get; set; }
                  public List<Modifier> Modifiers { get; set; } = new List<Modifier>();
                  public List<UserModifier> UserModifiers { get; set; } = new List<UserModifier>();
            }
            public class Modifier
            {
                  [Key]
                  public int Id { get; set; }
                  public string Name { get; set; }
                  public int Price { get; set; }
                  public int Modificator { get; set; }
                  public List<User> Users { get; set; } = new List<User>();
                  public List<UserModifier> UserModifiers { get; set; } = new List<UserModifier>();
            }
            public class UserModifier
            {
                  public int UsersId { get; set; }
                  public User? User { get; set; }
                  public int ModifiersId { get; set; }
                  public Modifier? Modifier { get; set; }
                  public int QuantityOfModifiers { get; set; }
            }
      }
}
