using System;
using System.Collections.Generic;
using System.Text;
using atFrameWork2.BaseFramework.LogTools;

namespace atFrameWork2.TestEntities
{
    public class User
    {
        public User(string login, string password, 
            string email, string firstName, string secondName, 
            Gender gender, string? additionalInfo = null, string? city = null)
        {
            Login = login;
            Password = password;
            Email = email;
            FirstName = firstName;
            SecondName = secondName;
            Gender = gender;
            AdditionalInfo = additionalInfo;
            City = city;
            Log.Info($"Новый пользователь создан: Логин {login}," +
                     $"Пароль {password}," +
                     $"Email {email}," +
                     $"Имя {firstName}," +
                     $"Фамилия {secondName}," +
                     $"Пол {gender}," +
                     $"Дополнительная информация {additionalInfo}," +
                     $"Город {city}");
        }

        /// <summary>
        /// Информация о пользователе
        /// </summary>
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Gender Gender { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? City { get; set; }
    }
}
