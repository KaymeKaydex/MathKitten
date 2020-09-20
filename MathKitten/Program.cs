using System;
using System.Diagnostics;
namespace MathKitten
{
    class Program
    {
        static void Main(string[] args)
        {
            Commands.Check();
            Commands.DrawKitten();
            Console.WriteLine("Добро пожаловать в программу Математическйи Котенок.\n Именно он будет вашим верным спутником в заучивании матана! \n Чтобы узнать список доступных команд введите /help");
            do
            {
                Console.Write(">> ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "/help":
                        Commands.Help();
                        break;
                    case "/exit":
                        Process.GetCurrentProcess().Kill();
                        break;
                    case "/now":
                        Commands.ShowSettings();
                        break;
                    case "/start":
                        Commands.Start();
                        break;
                    case "/check":
                        Commands.Check();
                        break;
                    default:
                        Console.WriteLine("Введена недопустимая команда!");
                        break;
                }
            } while (true);
        }
    }
}
