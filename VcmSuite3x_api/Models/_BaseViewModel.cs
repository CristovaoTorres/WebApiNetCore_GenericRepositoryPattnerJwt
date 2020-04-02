using System;
using VcmSuite3x_api.Core.Helper;
using VcmSuite3x_api.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api.Models
{
    public class BaseViewModel<T>
    {


        #region Constructors
        public BaseViewModel(T data)
        {
            Data = data;
            this.IsSuccess = true;
        }

        public BaseViewModel(T data, bool isSucess)
        {
            Data = data;
            this.IsSuccess = isSucess;
        }


        public BaseViewModel(T data, string message, string registerdBy)
        {
            this.Data = data;

            FeedbackMessage fmessage = new FeedbackMessage(message, eFeedbackType.SUCCESS, Guid.NewGuid(), registerdBy);
            List<FeedbackMessage> messages = new List<FeedbackMessage>();
            messages.Add(fmessage);

            this.IsSuccess = true;
            this.Messages = messages;
        }
        public BaseViewModel(Exception ex, Guid guid, string registeredBy)
        {
            List<FeedbackMessage> messages = new List<FeedbackMessage>
            {
                new FeedbackMessage(ex.Message, eFeedbackType.ERROR, guid, registeredBy)
            };

            if (ex.InnerException != null)
                messages.Add(new FeedbackMessage(ex.InnerException.Message, eFeedbackType.ERROR, guid, registeredBy));

            this.IsSuccess = false;
            this.Messages = messages;
        }



        #endregion

        #region Properties
        public T Data { get; }
        public bool IsSuccess { get; set; }
        public List<FeedbackMessage> Messages { get; set; } /* JSON Message List */
        #endregion




    }
}
