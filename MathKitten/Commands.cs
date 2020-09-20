using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MathKitten
{
    class Commands
    {
        public static void Help()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Чтобы начать работу программы просто добавьте в папку программы txt файлы с вопросами и введите команду /check \nНа данный момент доступны следующие команды : \n" +
                "/start - Начало работы \n" +
                "/mode - изменение режима заучивания(в разработке) \n"+
                "/exit - выход из программы \n"+
                "/help - меню команд\n"+
                "/now - текущие настройки программы\n" +
                "/check - проверка новых файлов в папке\n\n"
                + "Также в ответе доступны yes,no, в разных регистрах .Можете остаивть поле пустым и ваш вопрос засчиатется за верный"
                );
            Console.ResetColor();
        }
        public static void DrawKitten()
        {
            Console.WriteLine("                                                  (=`.`=)");
        }
        public static void Check()
        {
            List<string> temp = Directory.GetFiles(Environment.CurrentDirectory, "*.txt").ToList();
            for(int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Contains(".txt" )== false) temp.Remove(temp[i]);
            }
            Settings.files = temp;
        }
        public static void ShowSettings() {
            if (Settings.files.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Файлов не найдено!");
                Console.ResetColor();

            }
            else { 
            Console.WriteLine("Найденные файлы : ");
                foreach(string temp in Settings.files)
                {
                    Console.WriteLine(temp);
                }
            }
        }
        public static void Start()
        {
            if (Settings.files.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не найдено ни одного файла!Проверьте наличие файлов и введите /check чтобы обновить файлы в папке");
                Console.ResetColor();
            }
            else
            {
                Random rand = new Random();
                List<string> questions = new List<string>();
                foreach(string path in Settings.files)
                {
                    List<string> temp = File.ReadAllLines(path).ToList();
                    foreach (string element in temp) questions.Add(element);
                }
                while (questions.Count > 0)
                {
                    int randInt = rand.Next(0, questions.Count);
                    Console.WriteLine(questions[randInt]);
                    Console.WriteLine("Вы правильно ответили на этот вопрос? (y/n) ");
                    string YN = Console.ReadLine().ToLower();
                    switch (YN)
                    {
                        case "":
                        case "yes":
                        case "y":
                            questions.RemoveAt(randInt);
                            break;
                        
                    }
                }
                Console.WriteLine("Вы правильно ответили на все вопросы!");
            }
        }
    }
}
