using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_LINE.Models
{
    public class RequestDATA: EmployeeDATA
    {
        private List<RequestDATA> _lstReq = new List<RequestDATA>();

        public List<RequestDATA> LSTREQ
        {
            get { return _lstReq; }
            set { _lstReq = value; }
        }

        public string REQCODE { get; set; }
        public string USERID { get; set; }
        public string TITLE { get; set; }
        public string DESCRIPTION { get; set; }
        public string APPROVEID { get; set; }
        public DateTime CREATEDATE { get; set; }
    }
}