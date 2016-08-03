using System.Collections.Generic;
using Sabio.Web.Models.Requests.Analytics;

namespace Sabio.Web.Services.Analytics
{
    public interface IAnalyticsService
    {
        void Insert(AnalyticsAddRequest model, string userId);
        void InsertV2(AnalyticsAddRequest model, string userId);
    }
}