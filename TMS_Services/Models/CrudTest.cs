using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models
{
    public class CrudTest
    {
        private string objectTable { get; set; }
        private string action { get; set; }
        private string method { get; set; }
        private string idCredentials { get; set; }

        public CrudTest(string idCrendentials):this(string.Empty,string.Empty,string.Empty,idCrendentials) { }
        

        public CrudTest(string objectTable, string action, string method, string idCrendentials)
        {
            this.objectTable = objectTable;
            this.action = action;
            this.method = method;
            this.idCredentials = idCrendentials;
        }





    }
}