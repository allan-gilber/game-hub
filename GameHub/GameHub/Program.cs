using GameHub.Controllers;
using System;
using System.Globalization;

namespace GameHub
{
    public static class  GameHub
    {

        public static void Main(string[] args)
        {
            GameHubController.InitiateMenu();
            Console.Write("The application has been successfully terminated");
        }
    }
}