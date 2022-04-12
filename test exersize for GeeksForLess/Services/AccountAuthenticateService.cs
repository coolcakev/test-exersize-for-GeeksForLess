using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using test_exersize_for_GeeksForLess.Commands;
using test_exersize_for_GeeksForLess.Entity;
using test_exersize_for_GeeksForLess.Helper;
using test_exersize_for_GeeksForLess.Models.AccountModels;

namespace test_exersize_for_GeeksForLess.Services
{
    public interface IAccountAuthenticateService
    {
        Task<ClaimsIdentity> Login(LoginAccountModel model);
        Task<bool> RegisterPerson(RegisterAccountModel user);
    }

    public class AccountAuthenticateService : IAccountAuthenticateService
    {

        private readonly IAccountAuthenticateCommand _accountAuthenticateCommand;
        private readonly ApplicationContext _baseRepository;

        public AccountAuthenticateService(
            IAccountAuthenticateCommand accountAuthenticateCommand,
            ApplicationContext baseRepository)

        {
            _accountAuthenticateCommand = accountAuthenticateCommand;
            _baseRepository = baseRepository;
        }

        public async Task<ClaimsIdentity> Login(LoginAccountModel model)
        {
            var user = _baseRepository.Users.SingleOrDefault(x => x.UserLogin == model.UserLogin);
            if (user == null)
                return null;
            if ((string.IsNullOrWhiteSpace(model.Password)) || user.Password != SecurityHelper.ComputeSha256Hash(model.Password))
                return null;
            return await _accountAuthenticateCommand.ExecuteAsync(user); ;
        }
        public async Task<bool> RegisterPerson(RegisterAccountModel model)
        {
            model.ValidationMessage = new Dictionary<string, string>();
            Regex loginFormat = new Regex(@"(\D){4}");
            var isValidLoginFormat = loginFormat.IsMatch(model.UserLogin);
            if (!isValidLoginFormat)
            {
                model.ValidationMessage.Add("UserLogin", "Enter more than 4 symbols and login doesnt contain only with number");
            }

            var user = _baseRepository.Users.SingleOrDefault(x => x.UserLogin == model.UserLogin);
            if (user != null)
            {
                model.ValidationMessage.Add("UserLogin", "This Login exists");

            }

            Regex passwordFormat = new Regex(@"([a-zA-Z0-9]){7,}");
            var isValidPasswordFormat = passwordFormat.IsMatch(model.Password);
            if (!isValidPasswordFormat)
            {
                model.ValidationMessage.Add("Password", "Password lenth more than 7 and contains only with letter and number ");
            }
            if (model.Password != model.ConfirmPassword)
            {
                model.ValidationMessage.Add("ConfirmPassword", "Passwird doesnt match");
            }
            if (model.ValidationMessage.Count >= 1)
            {
                return false;
            }
            var newPerson = new User()
            {
                UserLogin = model.UserLogin,
                Password = SecurityHelper.ComputeSha256Hash(model.Password),


            };
            await _baseRepository.Users.AddAsync(newPerson);
            await _baseRepository.SaveChangesAsync();
            return true;
        }




    }

}

