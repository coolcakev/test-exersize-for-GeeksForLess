﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using test_exersize_for_GeeksForLess.Entity;

namespace test_exersize_for_GeeksForLess.Commands
{
    public interface IAccountAuthenticateCommand
    {
        Task<ClaimsIdentity> ExecuteAsync(User user);
    }
    public class AccountAuthenticateCommand : IAccountAuthenticateCommand
    {

        public async Task<ClaimsIdentity> ExecuteAsync(User user)
        {
            if (user == null)
                return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserLogin),              
                new Claim("UserId", user.Id.ToString()),               
                new Claim("UserLogin",user.UserLogin),
                
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return id;
        }
    }
}
