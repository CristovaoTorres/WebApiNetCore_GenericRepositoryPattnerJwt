using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{

    public class LoginViewModel
    {
        public LoginViewModel() { }

        public LoginViewModel(string apiKey, string apiSecretKey)
        {
            this.ApiKey = apiKey;
            this.ApiSecretKey = apiSecretKey;
        }

        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
    }

    public class UserViewModel
    {
        public UserViewModel(string apiToken, DateTime? apiTokenCreated, DateTime? apiTokenExpireOn)
        {
            this.ApiToken = apiToken;
            this.ApiTokenCreated = apiTokenCreated;
            this.ApiTokenExpireOn = apiTokenExpireOn;
        }

        public string ApiToken { get; set; }
        public DateTime? ApiTokenCreated { get; set; }
        public DateTime? ApiTokenExpireOn { get; set; }
    }


}
