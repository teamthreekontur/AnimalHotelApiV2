using Client.Models.Validation;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.User
{
    /// <summary>
    /// Информация для авторизации пользователя
    /// </summary>
    [Validator(typeof(UserAuthorizationInfoValidator))]
    public class UserAuthorizationInfo
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
