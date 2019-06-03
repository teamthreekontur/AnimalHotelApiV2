using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View = Client.Models.Place;
using Model = Models.Place;

namespace Models.Converters.Places
{
    public static class PlaceFilterInfoConverter
    {
        public static Model.PlaceFilterInfo Convert(View.PlaceFilterInfo placeFilterInfo)
        {
            return new Model.PlaceFilterInfo(placeFilterInfo.Name, 
                placeFilterInfo.Address, 
                placeFilterInfo.Description, 
                placeFilterInfo.PriceMin,
                placeFilterInfo.PriceMax,
                placeFilterInfo.OwnerId);
        }
    }
}
