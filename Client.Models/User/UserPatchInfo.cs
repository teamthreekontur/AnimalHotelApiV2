using Client.Models.Validation;
using FluentValidation.Attributes;

namespace Client.Models.User
{
    [Validator(typeof(UserPatchInfoValidator))]
    public class UserPatchInfo
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login;

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password;
    }
}
