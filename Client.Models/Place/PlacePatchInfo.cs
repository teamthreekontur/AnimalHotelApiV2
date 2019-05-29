namespace Client.Models.Place
{
    /// <summary>
    /// Информация для изменения передержки
    /// </summary>
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
    }
}
