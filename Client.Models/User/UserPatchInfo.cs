﻿using Client.Models.Validation;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

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

        /// <summary>
        /// Подтверждение пароля
        /// </summary>
        public string ConfirmPassword;

        /// <summary>
        /// Id сессии
        /// </summary>
        [Required]
        public string SessionId { get; set; }
    }
}
