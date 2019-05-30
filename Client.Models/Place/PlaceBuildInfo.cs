using Client.Models.Validation;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.Place
{
    /// <summary>
    /// Информация для создания передержки
    /// </summary>
    [Validator(typeof(PlaceBuildInfoValidator))]
    public class PlaceBuildInfo
    {
        /// <summary>
        /// Название передержки
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Адрес передержки
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Описание передержки
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Цена передержки
        /// </summary>
        [Required]
        public decimal Price { get; set; }
    }
}
