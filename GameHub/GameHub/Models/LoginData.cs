using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub.Models
{
    public class LoginData
    {
            public string Login { get; private set; }
            public string Password { get; private set; }
            public string PersonName { get; private set; }
            public decimal AccountBalance { get; private set; } = 0.00M;
            public LoginData(string login, string password, string personName)
            {
                Login = login;
                Password = password;
                PersonName = personName;
            }
            public override string ToString()
            {
                return "Login: " + Login + " | " +
                    "Password: " + Password + " | " +
                    "PersonName: " + PersonName + " | " +
                    "Account Balance: " + AccountBalance;
            }
    }
}
