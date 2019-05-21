using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Booking
{
    /// <summary>
    /// Бронь
    /// </summary>
    public class Booking : BookingInfo
    {
        /// <summary>
        /// Начало брони
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Конец брони
        /// </summary>
        public DateTime DateTo { get; set; }
    }
}
