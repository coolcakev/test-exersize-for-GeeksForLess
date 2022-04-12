using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_exersize_for_GeeksForLess.Models.AccountModels
{
    public class RegisterAccountModel
    {  
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Dictionary<string, string> ValidationMessage { get; set; }
    }
}
