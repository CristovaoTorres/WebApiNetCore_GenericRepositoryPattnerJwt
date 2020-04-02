using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x_api.Core.Helper
{

    public class FeedbackMessage
    {
        public FeedbackMessage() { }
        public FeedbackMessage(string value, eFeedbackType type, Guid guid, string registeredBy)
        {
            this.Guid = guid.ToString();
            this.Value = value;
            this.Type = type.ToString();
            this.RegisteredBy = string.IsNullOrEmpty(registeredBy) ? "NO_USER_LOGGED" : registeredBy;
        }

        public string Guid { get; set; }

        public string Type { get; set; }
        public string Value { get; set; }

        public string Registered { get { return DateTime.Now.ToString("yyyyMMdd hh:mm:ss"); } }
        public string RegisteredBy { get; set; }
    }


}
