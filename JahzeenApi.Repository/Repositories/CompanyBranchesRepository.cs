using Domain;
using JahzeenApi.Domain.Models;
using JahzeenApi.Repository.Interfaces;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Repository.Repositories
{
    public class CompanyBranchesRepository : Repository<CompanyBranches>, IComapnyBrachesRepository
    {
        private JahzeenContext _context;

        public CompanyBranchesRepository(
            JahzeenContext context
            ) : base(context)
        {
            _context = context;
        }
    }
}
