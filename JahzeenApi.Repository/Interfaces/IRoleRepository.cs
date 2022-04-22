using JahzeenApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Interfaces
{
    public interface IRoleRepository
    {
        Roles FirstOrDefault(Expression<Func<Roles, bool>> where);
        IList<Roles> GetRoles();
        void SetUserToken(int userId, string token);
        bool ValidateUserToken(int userId, string token);
        string ValidateResetToken(int userId);
        void SetUserResetToken(int userId, string token);
        string Validate2FA(int userId);
        void SetUser2FAToken(int userId, string token);
    }
}
