using System.ComponentModel.DataAnnotations;

namespace Client.Models.User
{
    /// <summary>
    /// Информация для регистрации пользователя
    /// </summary>
    public class UserRegistrationInfo
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
