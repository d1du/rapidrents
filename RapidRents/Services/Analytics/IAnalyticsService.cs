using System.Collections.Generic;
using RapidRents.Web.Models.Requests.Analytics;

namespace RapidRents.Web.Services.Analytics
{
    public interface IAnalyticsService
    {
        void Insert(AnalyticsAddRequest model, string userId);
        void InsertV2(AnalyticsAddRequest model, string userId);
    }
}
