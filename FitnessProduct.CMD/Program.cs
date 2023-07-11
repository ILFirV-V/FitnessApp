using Fitness.BL.Controller;
using FitnessProduct.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProduct.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветсвет учебное приложение");
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
            Console.WriteLine("Введите пол пользователя");
            var gender = Console.ReadLine();
            Console.WriteLine("Введите дату рождения пользователя");
            var birthday = DateTime.Parse(Console.ReadLine()); //TODO переписать на TryParse
            Console.WriteLine("Введите вес пользователя");
            var weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост пользователя");
            var height = double.Parse(Console.ReadLine());
            var userController = new UserController(name, gender, birthday, weight, height);
            userController.Save();
        }
    }
}
