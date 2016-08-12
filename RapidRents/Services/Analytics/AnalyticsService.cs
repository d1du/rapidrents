using RapidRents.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using RapidRents.Web.Models.Requests.Analytics;
using RapidRents.Web.Domain;

namespace RapidRents.Web.Services.Analytics
{
    public class AnalyticsService : BaseService, IAnalyticsService
    {
        public void Insert(AnalyticsAddRequest model, string userId)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Analytics_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserId", userId);
                   paramCollection.AddWithValue("@URL", model.URL);
                   paramCollection.AddWithValue("@TypeId", model.TypeId);
                   paramCollection.AddWithValue("@CategoryId", model.CategoryId);
                   paramCollection.AddWithValue("@Data", model.Data);
               });
        }

        public void InsertV2(AnalyticsAddRequest model, string userId)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Analytics_InsertV2"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {

                    SqlParameter ids = new SqlParameter("@Data", SqlDbType.Structured);

                    if (model.DataArr != null && model.DataArr.Any())
                    {
                        ids.Value = new RapidRents.Data.NVarcharTable(model.DataArr);
                    }

                    paramCollection.Add(ids);
                    paramCollection.AddWithValue("@UserId", userId);
                    paramCollection.AddWithValue("@URL", model.URL);
                    paramCollection.AddWithValue("@TypeId", model.TypeId);
                    paramCollection.AddWithValue("@CategoryId", model.CategoryId);

                }
               );
        }
    }
}
