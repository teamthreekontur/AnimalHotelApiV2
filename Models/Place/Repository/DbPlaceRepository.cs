using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Place.Repository
{
    public class DbPlaceRepository : IPlaceRepository
    {
        private readonly IMongoCollection<Place> places;
        public DbPlaceRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("AnimalHotel");
            places = database.GetCollection<Place>("Places");
        }

        public Place Create(PlaceCreateInfo createInfo)
        {
            if (createInfo == null)
            {
                throw new ArgumentNullException(nameof(createInfo));
            }

            var place = new Place()
            {
                Id = Guid.NewGuid(),
                Address = createInfo.Address,
                OwnerId = createInfo.IdOwner,
                Description = createInfo.Description,
                Name = createInfo.Name,
                Contacts = createInfo.Contacts
            };
            places.InsertOne(place);
            return place;
        }

        public Place Get(Guid placeId)
        {
            var searchResults = places.Find(x => x.Id == placeId);
            if (!searchResults.Any())
            {
                throw new PlaceNotFoundException(placeId);
            }
            return searchResults.First();
        }

        public List<Place> Get(PlaceFilterInfo placeFilter)
        {
            return places.Find(x => true).ToList();
        }

        public Place Patch(PlacePatchInfo patchInfo)
        {
            if (patchInfo == null)
            {
                throw new ArgumentNullException(nameof(patchInfo));
            }

            var place = Get(patchInfo.PlaceId);

            if (patchInfo.Name != null)
            {
                place.Name = patchInfo.Name;
            }

            if (patchInfo.Address != null)
            {
                place.Address = patchInfo.Address;
            }

            if (patchInfo.Description != null)
            {
                place.Description = patchInfo.Description;
            }

            if (patchInfo.Price != null)
            {
                place.Price = patchInfo.Price ?? 0;
            }

            if (patchInfo.Contacts != null)
            {
                place.Contacts = patchInfo.Contacts;
            }

            places.ReplaceOne(x => x.Id == place.Id, place);
            return place;
        }

        public bool Remove(Guid placeId)
        {
            var deleteResult = places.DeleteOne(x => x.Id == placeId);
            return deleteResult.DeletedCount > 0;
        }
    }
}
