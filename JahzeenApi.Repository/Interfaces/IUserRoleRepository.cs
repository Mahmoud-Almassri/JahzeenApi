using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.Models;
using Repository.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Interfaces
{
    public interface IUserRoleRepository
    {
        UserRoles Add(UserRoles entity);
        IEnumerable<UserRoles> Find(Expression<Func<UserRoles, bool>> predicate, params Expression<Func<UserRoles, object>>[] navigationProperties);
        IList<RoleDTO> GetRoles();
        UserRoles FirstOrDefault(Expression<Func<UserRoles, bool>> where, params Expression<Func<UserRoles, object>>[] navigationProperties);
        public UserRolesDTO RemoveEmployeeRole(UserRolesDTO userRoles);
        public UserRolesDTO AddEmployeeRole(UserRolesDTO entity);
    }
}
