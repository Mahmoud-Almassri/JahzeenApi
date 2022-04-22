using AutoMapper;
using Domain;
using JahzeenApi.Domain.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private JahzeenContext _context;
        public RoleRepository(JahzeenContext context)
        {
            _context = context;
        }

        public Roles FirstOrDefault(Expression<Func<Roles, bool>> where)
        {
            Roles result = _context.Roles.FirstOrDefault(where);
            return result;
        }
        public void SetUserToken(int userId, string token)
        {
            UserTokens userToken = _context.UserTokens.FirstOrDefault(x => x.UserId == userId && x.LoginProvider == "OTP");
            if (userToken == null)
            {
                UserTokens newUserToken = new UserTokens
                {
                    UserId = userId,
                    Name = "OTP Code",
                    LoginProvider = "OTP",
                    Value = token
                };
                _context.UserTokens.Add(newUserToken);
                _context.SaveChanges();
            }
            else
            {
                userToken.Value = token;
                _context.SaveChanges();
            }
        }
        public void SetUser2FAToken(int userId, string token)
        {
            UserTokens userToken = _context.UserTokens.FirstOrDefault(x => x.UserId == userId && x.LoginProvider == "2FA");
            if (userToken == null)
            {
                UserTokens newUserToken = new UserTokens
                {
                    UserId = userId,
                    Name = "OTP Code",
                    LoginProvider = "2FA",
                    Value = token
                };
                _context.UserTokens.Add(newUserToken);
                _context.SaveChanges();
            }
            else
            {
                userToken.Value = token;
                _context.SaveChanges();
            }
        }
        public void SetUserResetToken(int userId, string token)
        {
            UserTokens userToken = _context.UserTokens.FirstOrDefault(x => x.UserId == userId && x.LoginProvider == "ResetToken");
            if (userToken == null)
            {
                UserTokens newUserToken = new UserTokens
                {
                    UserId = userId,
                    Name = "OTP Code",
                    LoginProvider = "ResetToken",
                    Value = token
                };
                _context.UserTokens.Add(newUserToken);
                _context.SaveChanges();
            }
            else
            {
                userToken.Value = token;
                _context.SaveChanges();
            }
        }
        public string ValidateResetToken(int userId)
        {

            UserTokens userToken = _context.UserTokens.FirstOrDefault(x => x.UserId == userId && x.LoginProvider == "ResetToken");
            if (userToken != null)
            {
                return userToken.Value;
            }
            return "";
        }
        public string Validate2FA(int userId)
        {

            UserTokens userToken = _context.UserTokens.FirstOrDefault(x => x.UserId == userId && x.LoginProvider == "2FA");
            if (userToken != null)
            {
                return userToken.Value;
            }
            return "";
        }
        public bool ValidateUserToken(int userId, string token)
        {

            UserTokens userToken = _context.UserTokens.FirstOrDefault(x => x.UserId == userId && x.LoginProvider == "OTP");
            if (userToken.Value == token)
            {
                return true;
            }
            return false;
        }

        public IList<Roles> GetRoles()
        {
            List<Roles> roles = _context.Roles.ToList();
            return roles;
        }
    }
}
