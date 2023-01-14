using GameHub.Models;
using System.Globalization;

namespace GameHub.Controllers
{
    public class GameHubController
    {

            internal static readonly List<LoginData> SavedAccounts = new List<LoginData>();
            internal static LoginData? LoggedAccount { get; set; }
            private static CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-BR");
            private static NumberStyles style = NumberStyles.AllowDecimalPoint;

        public static void InitiateMenu()
        {
            MenuController.LoginMenu();
        }

    }
}
