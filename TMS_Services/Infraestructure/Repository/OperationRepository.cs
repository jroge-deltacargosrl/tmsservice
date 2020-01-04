using CookComputing.XmlRpc;
using OdooRpcWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Infraestructure.Repository
{
    public class OperationRepository : IOperationRepository
    {

        private readonly IConnectionApiOdooRepository connectionApiOdooRepository;
        private readonly ITaskConfigurationRepository taskConfigurationRepository;
        private readonly IInformationFileRepository informationFileRepository;

        private readonly OdooAPI odooApi;

        public OperationRepository(IConnectionApiOdooRepository connectionApiOdooRepository, ITaskConfigurationRepository taskConfigurationRepository, IInformationFileRepository informationFileRepository)
        {
            this.connectionApiOdooRepository = connectionApiOdooRepository;
            this.taskConfigurationRepository = taskConfigurationRepository;
            this.informationFileRepository = informationFileRepository;

            var modelApiOdoo = this.connectionApiOdooRepository.getConnectionCurrentApiOdoo();
            odooApi = getConnectionDefault(modelApiOdoo);

        }

        public IEnumerable<ProjectDTO> getAllOperations()
        {
            var filterProjects = new object[] { };

            int[] idsProjects = odooApi.Search("project.project", filterProjects);
            List<XmlRpcStruct> projectTuples = odooApi.Read("project.project", idsProjects, new object[] { })
                .ToList()
                .Cast<XmlRpcStruct>()
                .ToList();

            // obtener las tareas de los proyectos relacionados con el cliente
            List<int> idsTaskList = new List<int>();
            projectTuples.ForEach(
                (v) =>
                {
                    var filterTask = new object[1]
                    {
                        new object[]
                        {
                            "project_id","=",(int)v["id"]
                        }
                    };
                    idsTaskList.AddRange(odooApi.Search("project.task", filterTask));
                });

            // iterar los proyectos del cliente que solicita
            List<ProjectDTO> projectsResult = new List<ProjectDTO>();
            projectTuples.ForEach(
                (projectCurrent) =>
                {
                    projectsResult.Add(new ProjectDTO
                    {
                        id = (int)projectCurrent["id"],
                        name = (string)projectCurrent["name"]
                    });
                    // leer las tareas de cada proyecto
                    int[] idsTask = odooApi.Search("project.task", new object[1]
                    {
                        new object[]
                        {
                            "project_id","=",projectsResult.Last().id
                        }
                    });
                    List<XmlRpcStruct> taskTuples = odooApi.Read("project.task", idsTask, new object[] { }).ToList().Cast<XmlRpcStruct>().ToList();

                    // filtrar las tareas que el cliente no puede visualizar
                    List<string> taskNames = new List<string>();
                    
                    // obtener los nombres de las tareas de [ConfiguracionTarea]
                    var queryTaskConfiguration = taskConfigurationRepository.get(taskConf => taskConf.estado == 1).ToList().ConvertAll(e => (TaskConfigurationDTO)e);

                    queryTaskConfiguration.ToList()
                        .ForEach((v) => taskNames.Add(v.name));

                    // suprimir case sensitive
                    for (int i = 0; i < taskNames.Count(); i++)
                    {
                        taskNames[i] = taskNames[i].ToLower();
                    }

                    taskTuples.RemoveAll((v) => !taskNames.Contains(((string)v["name"]).ToLower()));

                    // iterar las tareas validas del proyecto actual
                    taskTuples.ForEach(
                        (taskCurrent) =>
                        {
                            int stageId = (int)((object[])taskCurrent["stage_id"])[0];
                            XmlRpcStruct stageXML = (XmlRpcStruct)odooApi.Read("project.task.type", new int[] { stageId }, new object[] { })[0];

                            var stageModel = new StageDTO
                            {
                                id = (int)stageXML["id"],
                                name = (string)stageXML["name"],
                                sequence = (int)stageXML["sequence"],
                                projectId = ((int[])stageXML["project_ids"])[0], // posible array de proyectos
                            };
                            if (!projectsResult.Last().stages.Contains(stageModel))
                            {
                                projectsResult.Last().stages
                                .Add(stageModel);

                                projectsResult.Last().stages = projectsResult.Last()
                                .stages
                                .OrderBy(s => s.sequence)
                                .ToList();

                            }
                            int lastProjectId = projectsResult.Last().id;
                            // relacionar la tarea actual obtenida de odoo, con su respectiva plantilla en base de datos, mejorar posteriormente
                            var taskTemplate = queryTaskConfiguration.FirstOrDefault(t => t.name.ToLower() == ((string)taskCurrent["name"]).ToLower());

                            // existe documento ya guardado
                            var documentInTask = (InformationFileDTO)informationFileRepository.getFirstOrDefault(i => i.id_proyecto == lastProjectId && i.id_tarea == taskTemplate.id);

                            bool documentExist = !isNull(documentInTask);

                            // obtener formato 
                            string documentFormat = documentExist ? documentInTask.format : string.Empty;

                            var taskModel = new TaskDTO
                            {
                                id = (int)taskCurrent["id"],
                                name = (string)taskCurrent["name"],
                                kanbanState = (string)taskCurrent["kanban_state"],
                                date_start = Convert.ToDateTime(taskCurrent["date_start"].ToString()),
                                stageId = stageId,
                                projectId = projectsResult.Last().id,
                                // agregar los nuevos atributos 
                                canUpload = Convert.ToBoolean(taskTemplate.allowDocuments),
                                uploaded = documentExist, // no se subio aun el documento (valor por defecto)
                                format = documentFormat
                            };
                            // agregar la tarea a su respectiva etapa y consecutivo proyecto
                            int index = projectsResult.Last().stages.IndexOf(stageModel);
                            projectsResult.Last().stages[index].tasks.Add(taskModel);
                        }
                    );
                });
            return projectsResult;
        }

        public IEnumerable<ProjectDTO> getAllOperationsByTypeAccess(int typeAccess, int id)
        {
            /* CREDENCIALES YA INSTANCIADAS 
             * 
             * var odooCredentials = new OdooConnectionCredentials("https://deltacargo-deltaqa-646890.dev.odoo.com", "deltacargo-deltaqa-646890", "deltacargomanuel2019@gmail.com", "delta011235813");
            var odooApi = new OdooAPI(odooCredentials);*/

            //  modificacion para asignacion por proyecto
            string propertyId = typeAccess == 1 ? "partner_id" : "user_id";

            var filterProject = new object[1]
            {
                new object[]
                {
                    //"partner_id","=",id
                    propertyId, "=", id
                }
            };

            int[] idsProjects = odooApi.Search("project.project", filterProject);
            List<XmlRpcStruct> projectTuples = odooApi.Read("project.project", idsProjects, new object[] { })
                .ToList()
                .Cast<XmlRpcStruct>()
                .ToList();

            // obtener las tareas de los proyectos relacionados con el cliente
            List<int> idsTaskList = new List<int>();
            projectTuples.ForEach(
                (v) =>
                {
                    var filterTask = new object[1]
                    {
                        new object[]
                        {
                            "project_id","=",(int)v["id"]
                        }
                    };
                    idsTaskList.AddRange(odooApi.Search("project.task", filterTask));
                });

            // iterar los proyectos del cliente que solicita
            List<ProjectDTO> projectsResult = new List<ProjectDTO>();
            projectTuples.ForEach(
                (projectCurrent) =>
                {
                    projectsResult.Add(new ProjectDTO
                    {
                        id = (int)projectCurrent["id"],
                        name = (string)projectCurrent["name"]
                    });
                    // leer las tareas de cada proyecto
                    int[] idsTask = odooApi.Search("project.task", new object[1]
                    {
                        new object[]
                        {
                            "project_id","=",projectsResult.Last().id
                        }
                    });
                    List<XmlRpcStruct> taskTuples = odooApi.Read("project.task", idsTask, new object[] { })
                    .ToList()
                    .Cast<XmlRpcStruct>()
                    .ToList();

                    // filtrar las tareas que el cliente no puede visualizar
                    List<string> taskNames = new List<string>();
                    //taskTuples.ForEach((task) => taskNames.Add((string)task["name"]));

                    // obtener los nombres de las tareas de [Configuracion_Tarea] de acuerdo al tipo de acceso : typeAccess = 1 (estado = 1) typeAccess = 2: (sin filtro)
                    // Mejorar el metodo posteriormente
                    IEnumerable<TaskConfigurationDTO> queryTaskConfiguration;
                    if (typeAccess == 1) // Portal Cliente
                    {
                         queryTaskConfiguration = taskConfigurationRepository.get(taskConf => taskConf.estado == 1).ToList().ConvertAll(e => (TaskConfigurationDTO)e);
                    }
                    else // typeAccess = 2 : Portal TMS Web
                    {
                        queryTaskConfiguration = taskConfigurationRepository.get().ToList().ConvertAll(e => (TaskConfigurationDTO)e);
                    }
                    
                    queryTaskConfiguration.ToList()
                        .ForEach((v) => taskNames.Add(v.name));

                    // suprimir case sensitive
                    for (int i = 0; i < taskNames.Count(); i++)
                    {
                        taskNames[i] = taskNames[i].ToLower();
                    }

                    taskTuples.RemoveAll((v) => !taskNames.Contains(((string)v["name"]).ToLower()));

                    // iterar las tareas validas del proyecto actual
                    taskTuples.ForEach(
                        (taskCurrent) =>
                        {
                            int stageId = (int)((object[])taskCurrent["stage_id"])[0];
                            XmlRpcStruct stageXML = (XmlRpcStruct)odooApi.Read("project.task.type", new int[] { stageId }, new object[] { })[0];

                            var stageModel = new StageDTO
                            {
                                id = (int)stageXML["id"],
                                name = (string)stageXML["name"],
                                sequence = (int)stageXML["sequence"],
                                projectId = ((int[])stageXML["project_ids"])[0], // posible array de proyectos
                            };
                            if (!projectsResult.Last().stages.Contains(stageModel))
                            {
                                projectsResult.Last().stages.Add(stageModel);
                                projectsResult.Last().stages = projectsResult.Last().stages.OrderBy(s => s.sequence).ToList();

                            }

                            int lastProjectId = projectsResult.Last().id;
                            // relacionar la tarea actual obtenida de odoo, con su respectiva plantilla en base de datos, mejorar posteriormente
                            var taskTemplate = queryTaskConfiguration.FirstOrDefault(t => t.name.ToLower() == ((string)taskCurrent["name"]).ToLower());

                            // existe documento ya guardado
                            var documentInTask = (InformationFileDTO)informationFileRepository.getFirstOrDefault(i => i.id_proyecto ==  lastProjectId && i.id_tarea == taskTemplate.id);

                            bool documentExist = !isNull(documentInTask);

                            // obtener formato 
                            string documentFormat = documentExist ? documentInTask.format : string.Empty;

                            var taskModel = new TaskDTO
                            {
                                id = (int)taskCurrent["id"],
                                name = (string)taskCurrent["name"],
                                kanbanState = (string)taskCurrent["kanban_state"],
                                date_start = Convert.ToDateTime(taskCurrent["date_start"].ToString()),
                                stageId = stageId,
                                projectId = projectsResult.Last().id,
                                // agregar los nuevos atributos 
                                canUpload = Convert.ToBoolean(taskTemplate.allowDocuments),
                                uploaded = documentExist, // no se subio aun el documento (valor por defecto)
                                format = documentFormat
                            };
                            // agregar la tarea a su respectiva etapa y consecutivo proyecto
                            int index = projectsResult.Last().stages.IndexOf(stageModel);
                            projectsResult.Last().stages[index].tasks.Add(taskModel);
                        }
                    );
                });
            return projectsResult;
        }

       
    }
}