﻿using AutoMapper;
using Domain;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private JahzeenContext _context;
        private IMapper _mapper;
        public UserRoleRepository(JahzeenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserRoles Add(UserRoles entity)
        {
            _context.UserRoles.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public UserRolesDTO AddEmployeeRole(UserRolesDTO entity)
        {
            UserRoles userRoles = new UserRoles
            {
                RoleId = entity.RoleId,
                UserId = entity.UserId
            };
            _context.UserRoles.Add(userRoles);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<UserRoles> Find(Expression<Func<UserRoles, bool>> predicate, params Expression<Func<UserRoles, object>>[] navigationProperties)
        {
            IQueryable<UserRoles> dbQuery = _context.Set<UserRoles>();

            foreach (Expression<Func<UserRoles, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<UserRoles, object>(navigationProperty);
            }

            return dbQuery.Where(predicate).AsNoTracking();
        }

        public UserRoles FirstOrDefault(Expression<Func<UserRoles, bool>> where, params Expression<Func<UserRoles, object>>[] navigationProperties)
        {
            UserRoles result = _context.UserRoles.FirstOrDefault(where);
            return result;
        }

        public IList<RoleDTO> GetRoles()
        {
            List<Roles> roles = _context.Roles.ToList();
            List<RoleDTO> mappedRoles = _mapper.Map<List<RoleDTO>>(roles);
            return mappedRoles;
        }

        public UserRolesDTO RemoveEmployeeRole(UserRolesDTO userRoles)
        {
            UserRoles user = new UserRoles
            {
                RoleId = userRoles.RoleId,
                UserId = userRoles.UserId
            };
            _context.UserRoles.Remove(user);
            _context.SaveChanges();
            return userRoles;
        }
    }
}
