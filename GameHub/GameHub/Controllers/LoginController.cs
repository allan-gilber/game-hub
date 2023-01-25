using GameHub.Models;
using static GameHub.Controllers.ConsolePrinterController;

namespace GameHub.Controllers
{
    public static class LoginController
    {

        internal static void CreateNewAccount()
        {
            Console.Clear();
            Console.WriteLine("Please type your login:");
            string? login = Console.ReadLine();
            if (login == null || login == "") { WriteInvalidLogin(); Console.ReadKey(); return; }
            int checkIfAccountAlreadyExists = GameHubController.SavedAccounts.FindIndex(account => account.Login == login);
            if (checkIfAccountAlreadyExists != -1) { WriteAccountAlreadyExists(); Console.ReadKey(); Console.ReadKey(); return; }

            Console.WriteLine("Please type a password for your account:");
            string? password = Console.ReadLine();
            if (password == null || password == "") { WriteInvalidPassword(); Console.ReadKey(); return; }

            Console.WriteLine("Please type your name:");
            string? personName = Console.ReadLine();
            if (personName == null || personName == "") { WriteInvalidName(); Console.ReadKey(); return; }

            GameHubController.SavedAccounts.Add(new LoginData(login, password, personName));
            WriteAccountCreationSuccesful();
            Console.ReadKey();
        }

        internal static  void DeleteAccount()
        {
            Console.Clear();
            Console.WriteLine("Type the account login to be deleted:");
            string? userInput = Console.ReadLine();

            if (userInput == null || userInput == "") { Console.WriteLine("invalid/null account"); Console.ReadKey(); return; }
            int indexOfTheAccount = GameHubController.SavedAccounts.FindIndex(account => account.Login == userInput);
            if (indexOfTheAccount == -1) { Console.WriteLine("Account not found"); Console.ReadKey(); return; }

            GameHubController.SavedAccounts.RemoveAt(indexOfTheAccount);
            Console.WriteLine("The account was successfully removed!");
            Console.ReadKey();
        }

        internal static  void Login()
        {
            Console.Clear();
            /* Console.WriteLine("Type your login:");
            string? userInputLogin = Console.ReadLine();
            if (userInputLogin == null || userInputLogin == "") { Console.WriteLine("Invalid account login"); Console.ReadKey(); return; }
            Console.Clear();

            Console.WriteLine("Type your password:");
            string? userInputPassword = Console.ReadLine();
            if (userInputPassword == null || userInputPassword == "") { WriteMessage(InvalidLoginMessage); Console.ReadKey(); return; }
            Console.Clear();

            int indexOfTheAccount = GameHubController.SavedAccounts.FindIndex(account => account.Login == userInputLogin);
            if (indexOfTheAccount == -1) { Console.WriteLine(InvalidLoginMessage); Console.ReadKey(); return; }

            LoginData findAccount = GameHubController.SavedAccounts.ElementAt(indexOfTheAccount);
            if (findAccount.Password != userInputPassword) { Console.WriteLine(InvalidLoginMessage); Console.ReadKey(); return; };
            
            GameHubController.LoggedAccount = findAccount;
            */
            GameHubController.LoggedAccount = new LoginData("a","b","c");
            GameHubController.SavedAccounts.Add(new LoginData("d", "e", "f"));
            Console.WriteLine("The login was successful!");
            MenuController.MainMenu();
        }

        internal static  void Logout()
        {
            GameHubController.LoggedAccount = null;
            MenuController.InternalMenuLoopControler = false;
            Console.WriteLine("Successfully logged out.");
            Console.ReadKey();
        }

    }
}
