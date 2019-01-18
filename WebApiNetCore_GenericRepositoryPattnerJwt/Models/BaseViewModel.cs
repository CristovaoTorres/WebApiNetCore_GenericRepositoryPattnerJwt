using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore_GenericRepositoryPattnerJwt.Util;

namespace WebApiNetCore_GenericRepositoryPattnerJwt.Models
{
    public class BaseViewModel<T>
    {

        #region Constructors
        public BaseViewModel(T data)
        {
            Data = data;
            this.IsSuccess = true;
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
            List<FeedbackMessage> messages = new List<FeedbackMessage>();
            messages.Add(new FeedbackMessage(ex.Message, eFeedbackType.ERROR, guid, registeredBy));

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
