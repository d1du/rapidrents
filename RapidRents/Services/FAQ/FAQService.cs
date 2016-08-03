using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Sabio.Data;
using Sabio.Web.Models.Requests.FAQ;
using Sabio.Web.Domain;
using Sabio.Web.Cache;
using Sabio.Web.Core;

namespace Sabio.Web.Services.FAQ
{
    public class FAQService : BaseService, IFAQService

    {
        public IUserService _userService = null;

        public FAQService(IUserService userService)
        {
            _userService = userService;
        }


        public int Insert(FAQAddRequest model) //comes from FAQApiController route. we instantiate new userId before running insertFAQ in FAQApiController.
        {
            int uid = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.FAQs_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Question", model.Question);
                   paramCollection.AddWithValue("@Category", model.Category);
                   paramCollection.AddWithValue("@Answer", model.Answer);
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

        public void Update(FAQUpdateRequest model)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.FAQs_Update"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Question", model.Question);
                   paramCollection.AddWithValue("@Category", model.Category);
                   paramCollection.AddWithValue("@Answer", model.Answer);
                   paramCollection.AddWithValue("@Id", model.Id);

               });

        }

        public List<Faq> Get()
        {
            List<Faq> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.FAQs_Select"
               , inputParamMapper: null
               , map: delegate (IDataReader reader, short set)
               {
                   Faq p = MapFaq(reader);

                   if (list == null)
                   {
                       list = new List<Faq>();
                   }

                   list.Add(p);

               }
               );

            return list;
        }

        private Faq MapFaq(IDataReader reader)
        {
            Faq p = new Faq();
            int startingIndex = 0; //startingOrdinal

            p.Id = reader.GetSafeInt32(startingIndex++);
            p.UserId = reader.GetSafeString(startingIndex++);
            p.Question = reader.GetSafeString(startingIndex++);
            p.Category = reader.GetSafeInt32(startingIndex++);
            p.Answer = reader.GetSafeString(startingIndex++);
            p.DateAdded = reader.GetSafeDateTime(startingIndex++);
            p.DateModified = reader.GetSafeDateTime(startingIndex++);

            return p;
        }

        public Faq GetById(int Id)
        {
            Faq p = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.FAQs_Select_By_Id"
           , inputParamMapper: delegate (SqlParameterCollection paramCollection)
           {
               paramCollection.AddWithValue("@Id", Id);
           }
           , map: delegate (IDataReader reader, short set)
           {
               p = MapFaq(reader);
           }
           );

            return p;
        }

        public void Delete(int Id)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.FAQs_Delete"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", Id);
               });

        }
    }

}