using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.TestEntities
{
    public class User
    {
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
