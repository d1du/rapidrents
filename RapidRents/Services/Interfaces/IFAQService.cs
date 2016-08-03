using System.Collections.Generic;
using Sabio.Web.Domain;
using Sabio.Web.Models.Requests.FAQ;

namespace Sabio.Web.Services.FAQ
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