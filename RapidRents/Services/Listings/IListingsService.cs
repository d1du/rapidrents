using Sabio.Web.Domain.Listings;
using Sabio.Web.Models.Requests.Listings;
using System.Collections.Generic;
using System.Data;

namespace Sabio.Web.Services.Listings
{
    public interface IListingsService
    {
        Listing GetListingsById(int id);
        Listing GetListingByAddressId(int Id);
        Listing GetListingByLiId(int id);

        List<Listing> GetAllListings();
        List<Listing> GetFeatured();
        List<Listing> GetLatest();

        List<Listing> GetListingsByRentCost(ListingsSearchRequest model);
        List<Listing> GetListingsByAvailabilityDate(ListingsSearchRequest model);
        List<Listing> GetListingsByHasParking(ListingsSearchRequest model);
        List<Listing> GetListingsByLeaseTerms(ListingsSearchRequest model);

        PagedList<Listing> GetAllPropListings(int pageNumber, int pageSize);
        PagedList<Listing> GetFavoriteListings(string UserId);
        PagedList<Domain.Address.Address> GetAllMapListingsAddresses(int pageIndex, int pageSize);

        int PLW_Insert(PLWAddRequest model);
        int InsertNewListing(ListingsAddRequest model);
        void UpdateListingsRecord(ListingsUpdateRequest model);
        void DeleteListingsById(int id);

        T MapListing<T>(IDataReader reader, int actualStartingIndex = 0) where T : Listing, new();
    }
}