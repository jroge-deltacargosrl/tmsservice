using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.API;
using TMS_Services.Models;
using TMS_Services.Models.DAL;
using TMS_Services.Models.DTO;
using TMS_Services.Models.ODOO_Conexion;
using static TMS_Services.App_Utils.UtilsApiTms;


namespace TMS_Services.Controllers
{
    public class TestCrudController : ApiController
    {
        //private readonly IMapper mapper;
        private readonly ProjectDAL projectDAL;

        public TestCrudController(ProjectDAL projectDAL)
        {
            this.projectDAL = projectDAL;
        }

        /*public TestCrudController(IMapper mapper)
        {
            this.mapper = mapper;
            // constructor sin parametros
            mapper = AutoMapperWebProfile.Run();
        }*/


        [Route("api/createCredentialApi/")]
        [HttpPost]
        public UsuarioModel addUserWithCredentialsApi([FromBody] UsuarioModel usuario)
        {
            return null;
        }

        [Route("api/testarray/")]
        [HttpGet]
        public string testArray([FromUri]int[] ids)
        {
            return string.Join(",", ids);
        }


        [Route("api/accessApi/")]
        [HttpPost]
        public IHttpActionResult /*ActionResultTms<UsuarioModel>*/ accessApiOdoo([FromBody] CredencialApiModel credencialApi)
        {
            if (credencialApi.applyRequeridFields())
            {
                long id = credencialApi.accessApi();
                // codigo a optimizar
                string nameMsg, passMsg;
                if (!id.Equals(default))
                {
                    nameMsg = "usuario se conecto exitosamente";
                    passMsg = "se generaron credenciales de acceso";
                }
                else
                {
                    nameMsg = "no pudo conectarse!!";
                    passMsg = "no pudo conectarse!!";
                }
                return new ActionResultApi<UsuarioModel>(
                    HttpStatusCode.OK
                    , new UsuarioModel
                    {
                        //idRol = (int)id,
                        userName = $"{credencialApi.userName} : {nameMsg} ",
                        password = $" Contraseña de Acceso a la API ODOO : {passMsg} "
                    }
                    , Request);
            }
            return new ActionResultApi<UsuarioModel>(HttpStatusCode.BadRequest, null, Request);
        }


        #region "Metodos de Prueba"

        [Route("api/getSchemmaOdoo/")]
        public IHttpActionResult getTablesODOO()
        {
            return Ok(getTablesOdoo());
        }


        /// <summary>
        /// Metodo para obtener los datos JSON a prueba para la prueba de los postulantes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/operacionesx")]
        public IHttpActionResult getOperacionesFicticias()
        {
            List<OperationTest> operationTests = new List<OperationTest>
            {
                new OperationTest
                {
                    id = 1,
                    nombre = "Chile - Descarguío a Piso",
                    etapas = new List<EtapaTest>()
                    {
                        new EtapaTest
                        {
                            id = 1,
                            nombre = "etapa 1",
                            orden = 1,
                            id_operacion = 1,
                            tareas = new List<TaskTest>()
                            {
                                new TaskTest
                                {
                                    id = 1,
                                    nombre = "Tarea 1",
                                    descripcion = "Descripcion Tarea 1",
                                    id_etapa = 1
                                },
                                new TaskTest
                                {
                                    id = 2,
                                    nombre = "Tarea 2",
                                    descripcion = "Descripcion Tarea 2",
                                    id_etapa = 1
                                }
                            }
                        },
                        new EtapaTest
                        {
                            id = 2,
                            nombre = "etapa 2",
                            orden = 2,
                            id_operacion = 1,
                            tareas = new List<TaskTest>()
                            {
                                new TaskTest
                                {
                                    id = 4,
                                    nombre = "Tarea 4",
                                    descripcion = "Descripcion Tarea 4",
                                    id_etapa = 2
                                },
                                new TaskTest
                                {
                                    id = 5,
                                    nombre = "Tarea 5",
                                    descripcion = "Descripcion Tarea 5",
                                    id_etapa = 2
                                }
                            }
                        },
                        new EtapaTest
                        {
                            id = 3,
                            nombre = "etapa 3",
                            orden = 3,
                            id_operacion = 1,
                            tareas = new List<TaskTest>()
                            {
                                new TaskTest
                                {
                                    id = 6,
                                    nombre = "Tarea 6",
                                    descripcion = "Descripcion Tarea 6",
                                    id_etapa = 2
                                },
                                new TaskTest
                                {
                                    id = 7,
                                    nombre = "Tarea 7",
                                    descripcion = "Descripcion Tarea 7",
                                    id_etapa = 2
                                }
                            }
                        }
                    }
                },
                new OperationTest
                {
                    id = 2,
                    nombre = "OP-20190754 - Nutriagro",
                    etapas = new List<EtapaTest>()
                    {
                        new EtapaTest
                        {
                            id = 1,
                            nombre = "etapa 1",
                            orden = 1,
                            id_operacion = 2,
                            tareas = new List<TaskTest>()
                            {
                                new TaskTest
                                {
                                    id = 1,
                                    nombre = "Tarea 1",
                                    descripcion = "Descripcion Tarea 1",
                                    id_etapa = 1
                                },
                                new TaskTest
                                {
                                    id = 2,
                                    nombre = "Tarea 2",
                                    descripcion = "Descripcion Tarea 2",
                                    id_etapa = 1
                                }
                            }
                        },
                        new EtapaTest
                        {
                            id = 2,
                            nombre = "etapa 2",
                            orden = 2,
                            id_operacion = 2,
                            tareas = new List<TaskTest>()
                            {
                                new TaskTest
                                {
                                    id = 4,
                                    nombre = "Tarea 4",
                                    descripcion = "Descripcion Tarea 4",
                                    id_etapa = 2
                                },
                                new TaskTest
                                {
                                    id = 5,
                                    nombre = "Tarea 5",
                                    descripcion = "Descripcion Tarea 5",
                                    id_etapa = 2
                                }
                            }
                        },
                        new EtapaTest
                        {
                            id = 3,
                            nombre = "etapa 3",
                            orden = 3,
                            id_operacion = 2,
                            tareas = new List<TaskTest>()
                            {
                                new TaskTest
                                {
                                    id = 6,
                                    nombre = "Tarea 6",
                                    descripcion = "Descripcion Tarea 6",
                                    id_etapa = 2
                                },
                                new TaskTest
                                {
                                    id = 7,
                                    nombre = "Tarea 7",
                                    descripcion = "Descripcion Tarea 7",
                                    id_etapa = 2
                                }
                            }
                        }
                    }
                },
            };
            return Ok(operationTests);
        }


        public class OperationTest
        {
            public int id { get; set; }
            public string nombre { get; set; }
            /*public DateTime fechaInicio { get; set; }
            public DateTime fechaFin { get; set; }*/
            public IEnumerable<EtapaTest> etapas { get; set; }


        }

        public class EtapaTest
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public int orden { get; set; }
            //public DateTime fecha { get; set; }
            public int id_operacion { get; set; }

            public IEnumerable<TaskTest> tareas { get; set; }



        }


        public class TaskTest
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public int id_etapa { get; set; }
        }




        // metodo de prueba
        [Route("api/testMapping/")]
        [HttpGet]
        public IHttpActionResult/*IEnumerable<AccesoApiModelView>*/ testMapping()
        {
            return null;
            //return Ok(App_Utils.UtilsApiTms.exampleCnxOdooADONET());
            /*IEnumerable<CredencialApiModel> objSource = App_Utils.UtilsApiTms.getListCredenciales();*/

            /*var objSource = new CredencialApiModel
            {
                userName = "manuel",
                password = "manuXD",
                relationTipoCredencial = new TipoCredencialModel
                {
                    id = 1,
                    descripcion = "tipoc1",
                    observacion = "obs1"
                }
            };*/

            /*var objDest = mapper.Map<IEnumerable<AccesoApiModelView>>(objSource);
            return objDest;*/

            //var lparsing  = mapper.Map<List<AccesoApiModelView>>(l1);

            //AutoMapper.Mapper.Map(l1, lparsing);

            //return lparsing;

        }

        // metodo de conexion a la base de datos SQL Server
        [Route("api/getUsers/")]
        [HttpGet]
        public IHttpActionResult getUsuarios()
        {
            List<UsuarioModel> usuarioModels = new List<UsuarioModel>();
            SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
            {
                DataSource = "deltacargosql.database.windows.net",
                InitialCatalog = "DeltaDB",
                UserID = "deltasa",
                Password = "Delta123#"
            };
            SqlConnection cnn = new SqlConnection(sConnB.ConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM usuario", cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                usuarioModels.Add(new UsuarioModel
                {
                    userName = dr["email"].ToString(),
                    password = dr["password"].ToString()
                });
            }
            cnn.Close();
            return Ok(usuarioModels);

        }

        /*[Route(ACCESS_USER)] // cmbiar la URL
        [HttpPost]
        public ActionResultApi<UserResponseDTO> accessClient([FromBody] UserDTO request)
        {
            var loginResult = CustomerDAL.logIn(request);
            return new ActionResultApi<UserResponseDTO>(HttpStatusCode.OK, loginResult, Request);
        }*/



        /*// reconfigurar este metodo con las entidades correspondientes
        [Route("api/projectsByClient/")]
        [HttpPost]
        public ActionResultApi<IEnumerable<ProjectDTO>> getTaskProjectsByCustommers(long idClient)
        {
            return new ActionResultApi<IEnumerable<ProjectDTO>>(
                HttpStatusCode.OK,
                projectDAL.getAllOperationsByTypeAccess(idClient),
                Request);

        }*/
        #endregion





    }
}
