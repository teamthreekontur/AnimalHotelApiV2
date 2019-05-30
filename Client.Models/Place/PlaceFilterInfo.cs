namespace Client.Models.Place
{
    /// <summary>
    /// Фильтр по передержкам
    /// </summary>
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
        /// Фильтр по цене
        /// </summary>
        public decimal? Price { get; set; }
    }
}
