using Client.Models.Validation;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.User
{
    /// <summary>
    /// Информация для регистрации пользователя
    /// </summary>
    [Validator(typeof(UserRegistrationInfoValidator))]
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

        /// <summary>
        /// Подтверждение пароля
        /// </summary>
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
