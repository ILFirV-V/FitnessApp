using Fitness.BL.Controller;
using System;

namespace FitnessProduct.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветсвет учебное приложение");
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUsesr)
            {
                Console.WriteLine("Введите пол пользователя");
                var gender = Console.ReadLine();
                var birthday = ParseDate("дата");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");
                userController.SetNewUserData(gender, birthday, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
            userController.Save();
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}");
                }
            }
        }

        private static DateTime ParseDate(string name)
        {
            while (true)
            {
                Console.WriteLine("Введите дату рождения пользователя(dd:MM:yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthday))
                {
                    return birthday;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты!");
                }
            }
        }
    }
}
