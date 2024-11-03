using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClient.MVVM.Model
{
    public class UserModel
    {
        public string Username { get; set; }
        public string UID { get; set; }

        public UserModel(string username, string uid)
        {
            Username = username;
            UID = uid;
        }
    }
}
