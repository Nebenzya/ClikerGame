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

                  //public List<Game> Games { get; set; }
            }
      }
}
