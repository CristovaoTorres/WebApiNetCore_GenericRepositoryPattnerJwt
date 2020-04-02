using System;
using System.Collections.Generic;

namespace VcmSuite3x_api.Core.Models
{
    public partial class ApplicationHistory
    {
        public int Id { get; set; }
        public int? CallerApplicationId { get; set; }
        public string CallerIpAddress { get; set; }
        public string CallerUrl { get; set; }
        public string CallerMethod { get; set; }
        public int ReturnedHttpCode { get; set; }
        public int? ReturnedId { get; set; }
        public int? ReturnedTotalRecords { get; set; }
        public int ReturnedInternalCode { get; set; }
        public string ReturnInternalMessage { get; set; }
        public DateTime Registered { get; set; }
        public string RegisteredBy { get; set; }
    }
}
