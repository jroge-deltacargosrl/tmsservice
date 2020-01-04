using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models.DAL
{
    public class SingletonDAL<T,IntefazSingleton> where T: class, IntefazSingleton, new()
    {
        private SingletonDAL() { }

        private static T instance = null;
        public static IntefazSingleton getInstance
        {
            get
            {
                if (isNull(instance))
                {
                    instance = new T();
                }
                return instance;
            }
        }

      


    }
}