using System.Collections.Generic;
using Sabio.Web.Domain;
using Sabio.Web.Models.Requests.Amenities;

namespace Sabio.Web.Services.AmenitiesServices
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