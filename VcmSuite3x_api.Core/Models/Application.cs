using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public string ApiToken { get; set; }
        public DateTime? ApiTokenCreated { get; set; }
        public DateTime? ApiTokenExpireOn { get; set; }
        public string EmailPreferences { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}
