using System.Collections.Generic;
using RapidRents.Web.Domain;
using RapidRents.Web.Models.Requests.FAQ;

namespace RapidRents.Web.Services.FAQ
{
    public interface IFAQService
    {
        void Delete(int Id);
        List<Faq> Get();
        Faq GetById(int Id);
        int Insert(FAQAddRequest model);
        void Update(FAQUpdateRequest model);
    }
}
