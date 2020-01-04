using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.Types
{
    public enum TIPO_RUTA_API
    {
        [Description("common")]
        ACCESO = 1,

        [Description("object")]
        OBJETO = 2,


    }
}