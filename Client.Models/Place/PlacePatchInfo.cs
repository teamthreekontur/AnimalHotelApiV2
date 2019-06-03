using Client.Models.Validation;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.Place
{
    /// <summary>
    /// Информация для изменения передержки
    /// </summary>
    [Validator(typeof(PlacePatchInfoValidator))]
    public class PlacePatchInfo
    {
        /// <summary>
        /// Новое название передержки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Новый адрес передержки
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Описание передержки
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Цена передержки
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Контакты
        /// </summary>
        public string Contacts { get; set; }

        /// <summary>
        /// Id сессии
        /// </summary>
        [Required]
        public string SessionId { get; set; }
    }
}
