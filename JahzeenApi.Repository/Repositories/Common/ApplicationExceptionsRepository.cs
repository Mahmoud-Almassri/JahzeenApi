using Domain;
using JahzeenApi.Domain.Models.Common;
using Repository.Interfaces.Common;

namespace Repository.Repositories.Common
{
    public class ApplicationExceptionsRepository : IApplicationExceptionsRepository
    {
        #region [Context]
        protected JahzeenContext Context;
        #endregion

        public ApplicationExceptionsRepository(JahzeenContext context)
        {
            Context = context;
        }

        public ApplicationExceptions WriteException(ApplicationExceptions ex)
        {
            Context.Set<ApplicationExceptions>().Add(ex);
            Context.SaveChanges();
            Context.Entry(ex).GetDatabaseValues();

            return ex;
        }
    }
}
