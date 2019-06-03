using Client.Models.Validation;
using FluentValidation.Attributes;

namespace Client.Models.Place
{
    /// <summary>
    /// Фильтр по передержкам
    /// </summary>
    [Validator(typeof(PlaceFilterInfoValidator))]
    public class PlaceFilterInfo
    {
        /// <summary>
        /// Фильтр по названию
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фильтр по адресу
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Фильтр по описанию
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Фильтр по минимальной цене
        /// </summary>
        public decimal? PriceMin { get; set; }

        /// <summary>
        /// Фильтр по максимальной цене
        /// </summary>
        public decimal? PriceMax { get; set; }

        /// <summary>
        /// Фильтр по пользователю
        /// </summary>
        public string OwnerId { get; set; }
    }
}
