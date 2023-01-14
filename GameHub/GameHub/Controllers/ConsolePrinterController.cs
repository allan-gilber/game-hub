using static System.Console;

namespace GameHub.Controllers
{
    public static class ConsolePrinterController
    {
        public static string InvalidLoginMessage { get; } = "Failed to login: incorrect login and/or password.";
        public static string ReturnToMainMenuMessage { get; } = "Returning to main menu...";
        public static string ReturnToLoginMenuMessage { get; } = "Returning to login menu...";

        public static void WriteInvalidOptionMessage() { 
            WriteLine("Invalid option. Please type a valid number from the menu below:"); 
        } 

        public static void WriteMessage(string Message)
        {
            Console.WriteLine(Message);
        }

        public static void WriteLoginMenu()
        {
            Clear();
            WriteLine("1 - Login");
            WriteLine("2 - Create Account");
            WriteLine("0 - Shutdown System");
            Write("Type your option: ");
        }


        public static void WriteInternalMenu()
        {
            Clear();
            WriteLine("1 - Delete account");
            WriteLine("2 - List all account data");
            WriteLine("3 - Account details");
            WriteLine("4 - Balance");
            WriteLine("5 - Withdrawn");
            WriteLine("6 - Deposit");
            WriteLine("7 - Transfer");
            WriteLine("0 - Logout");
            Write("Type your option: ");
        }

        public static void WriteInvalidLogin()
        {
            Console.WriteLine("Invalid login!\n{0}", ReturnToLoginMenuMessage);
        }

        public static void WriteAccountAlreadyExists()
        {
            Console.WriteLine("Account login already exists! {0}", ReturnToLoginMenuMessage);
        }

        public static void WriteInvalidPassword()
        {
            Console.WriteLine("invalid/null Password!\n{0}", ReturnToLoginMenuMessage);
        }

        public static void WriteInvalidName()
        {
            Console.WriteLine("Invalid name!\n{0}", ReturnToLoginMenuMessage);
        }

        public static void WriteAccountCreationSuccesful()
        {
            Console.WriteLine("Account successfully created! {0}", ReturnToLoginMenuMessage);
        }


    }
}
