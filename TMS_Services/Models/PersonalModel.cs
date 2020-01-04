using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models
{
    public class PersonalModel
    {
        public long id { get; set; }

        public PersonalModel() : this(default(long)) { }
        public PersonalModel(long id)
        {
            this.id = id;
        }

        public PersonalModel(PersonalModel objCopy)
        {
            if (!isNull(objCopy))
            {
                id = objCopy.id; 
            }
        }

    }
}