using Domain;
using JahzeenApi.Domain.Models;
using Repository.Interfaces;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class AppSettingsRepository  : Repository<AppSettings>, IAppSettingsRepository
    {
        private JahzeenContext _context;

        public AppSettingsRepository(JahzeenContext context) : base(context)
        {
            _context = context;
        }
    }
}
