using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Place
{
    /// <summary>
    /// Информация для поиска передержки
    /// </summary>
    public class PlaceFilterInfo
    {
        /// <summary>
        /// Поиск передержки по заданным полям
        /// </summary>
        /// <param name="name">Заголовок передержки</param>
        /// <param name="address">Адрес передержки</param>
        /// <param name="description">Описание передержки</param>
        /// <param name="price">Цена передержки</param>
        public PlaceFilterInfo(string name = null, string address = null, string description = null, decimal? price = 0)
        {
            Name = name;
            Address = address;
            Description = description;
            Price = price;
        }

        /// <summary>
        /// Заголовок передержки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес передержки
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
