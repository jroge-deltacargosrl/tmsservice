using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.Types
{
    public enum TIPO_METODO_API
    {
        [Description("authenticate")]
        AUTENTICACION = 1,

        [Description("search")]
        LISTAR_IDS_REGISTROS = 2,

        [Description("read")]
        LISTAR_REGISTROS = 3,
        
        [Description("search_count")]
        CANTIDAD_REGISTROS = 4,

        [Description("fields_get")]
        LISTAR_METADATOS_OBJETO = 5,

        [Description("search_read")]
        LISTAR_REGISTROS_COMPLETOS= 6,

        [Description("create")]
        CREAR_REGISTRO = 7,

        [Description("update")]
        ACTUALIZAR_REGISTRO = 8,

        [Description("delete")]
        ELIMINAR_REGISTRO = 9,



    }
}