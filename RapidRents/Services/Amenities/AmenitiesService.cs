using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using RapidRents.Data;
using RapidRents.Web.Models.Requests.Amenities;
using RapidRents.Web.Domain;
using RapidRents.Web.Core;
using RapidRents.Web.Cache;

namespace RapidRents.Web.Services.AmenitiesServices
{
    public class AmenitiesService : BaseService, IAmenitiesService
    {
        public IUserService _userService = null;
        public int Insert(AmenitiesAddRequest model) //comes from FAQApiController route. we instantiate new userId before running insertFAQ in FAQApiController.
        {
            int uid = 0;


            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Amenities_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Amenity", model.AmenityName);
                   paramCollection.AddWithValue("@TypeId", model.TypeId);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@UserId", _userService.GetCurrentUserId());

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out uid);
               }
               );

            return uid;
        }

        public void Update(AmenitiesUpdateRequest model)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Amenities_Update"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Amenity", model.AmenityName);
                   paramCollection.AddWithValue("@TypeId", model.TypeId);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@Id", model.Id);

               });
        }

        public List<Amenity> Get()
        {
            List<Amenity> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Amenities_Select"
               , inputParamMapper: null
               , map: delegate (IDataReader reader, short set)
               {
                   Amenity p = MapAmenities(reader);

                   if (list == null)
                   {
                       list = new List<Amenity>();
                   }

                   list.Add(p);
               }
               );

            return list;
        }

        public Amenity MapAmenities(IDataReader reader)
        {
            Amenity p = new Amenity();
            int startingIndex = 0; //startingOrdinal


            p.Id = reader.GetSafeInt32(startingIndex++);
            p.UserId = reader.GetSafeString(startingIndex++);
            p.AmenityName = reader.GetSafeString(startingIndex++);
            p.TypeId = reader.GetSafeBool(startingIndex++);
            p.Description = reader.GetSafeString(startingIndex++);
            p.DateAdded = reader.GetSafeDateTime(startingIndex++);
            p.DateModified = reader.GetSafeDateTime(startingIndex++);

            return p;
        }

        public Amenity GetById(int Id)
        {
            Amenity p = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Amenities_Select_By_Id"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", Id);
               }
               , map: delegate (IDataReader reader, short set)
               {
                   p = MapAmenities(reader);

               }
               );

            return p;

        }

        public void Delete(int Id)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Amenities_Delete"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", Id);
               });

        }

        
    }
}
