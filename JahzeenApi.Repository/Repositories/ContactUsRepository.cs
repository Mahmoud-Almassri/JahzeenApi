using Domain;
using JahzeenApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;
using Repository.Repositories.Common;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ContactUsRepository : Repository<ContactUs>, IContactUsRepository
    {
        private JahzeenContext _context;

        public ContactUsRepository(
            JahzeenContext context
            ) : base(context)
        {
            _context = context;
        }
    }
}
