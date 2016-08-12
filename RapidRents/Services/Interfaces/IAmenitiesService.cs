using System.Collections.Generic;
using RapidRents.Web.Domain;
using RapidRents.Web.Models.Requests.Amenities;

namespace RapidRents.Web.Services.AmenitiesServices
{
    public interface IAmenitiesService
    {
        void Delete(int Id);
        List<Amenity> Get();
        Amenity GetById(int Id);
        int Insert(AmenitiesAddRequest model);
        void Update(AmenitiesUpdateRequest model);

    }
}
