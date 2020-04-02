using System;

namespace VcmSuite3x_api.Core.Models
{
    internal interface IAuditable
    {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
        string UpdatedBy { get; set; }
    }
}