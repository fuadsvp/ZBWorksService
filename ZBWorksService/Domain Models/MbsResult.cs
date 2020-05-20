using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBillSoft.DomainModel
{
    public class MbsResult
    {
        public bool Status { get; set; }

        public List<string> MessageList { get; set; }

        public object Result { get; set; }

        public object ExtraResult { get; set; }

        public int StatusCode { get; set; }

        public string FirstMessage
        {
            get
            {
                if (MessageList == null || MessageList.Count == 0)
                {
                    return "";
                }
                return MessageList[0];
            }
        }

        public MbsResult()
        {
        }

        public MbsResult(bool status, string message)
        {
            Status = status;
            Result = null;
            StatusCode = 0;
            MessageList = new List<string>();
            MessageList.Add(message);
        }

        public MbsResult(bool status, string message, int statusCode)
        {
            Status = status;
            Result = null;
            StatusCode = statusCode;
            MessageList = new List<string>();
            MessageList.Add(message);
        }

        public MbsResult(bool status, object result, string message = null)
        {
            Status = status;
            Result = result;
            StatusCode = 0;
            MessageList = new List<string>();
            if (message != null)
            {
                MessageList.Add(message);
            }
        }

        public MbsResult(bool status, List<string> msgList)
        {
            Status = status;
            Result = null;
            StatusCode = 0;
            MessageList = msgList;
        }
    }
}
