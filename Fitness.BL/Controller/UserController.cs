using System;
using FitnessProduct.BL.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User CurrentUser { get; }
        /// <summary>
        /// Пользователи.
        /// </summary>
        public List<User> Users { get; }
        /// <summary>
        /// флаг на нового пользователя.
        /// </summary>
        public bool IsNewUsesr { get; } = false;
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName) 
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));  
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(user => user.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUsesr = true;
                Save();
            }
        }
        /// <summary>
        /// Получить сохранненый список пользователей
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> usersData)
                {
                    return usersData;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        public void SetNewUserData(
            string genderName, 
            DateTime birthDate, 
            double weight = 1, 
            double height = 1)
        {
            //Проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя приложения.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
    }
}