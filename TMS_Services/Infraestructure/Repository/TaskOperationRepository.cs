using CookComputing.XmlRpc;
using OdooRpcWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.Infraestructure.Interfaces;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Infraestructure.Repository
{
    public class TaskOperationRepository : ITaskOperationRepository
    {

        private readonly IConnectionApiOdooRepository connectionApiOdooRepository;
        private readonly OdooAPI odooAPI;

        public TaskOperationRepository(IConnectionApiOdooRepository connectionApiOdooRepository)
        {
            this.connectionApiOdooRepository = connectionApiOdooRepository;

            var defaulCnnApi = this.connectionApiOdooRepository.getConnectionCurrentApiOdoo();
            odooAPI = getConnectionDefault(defaulCnnApi);
        }


        public string getNameTaskByIdInERP(int taskIdErp)
        {
            /*var odooCredentials = new OdooConnectionCredentials("https://deltacargo-deltaqa-646890.dev.odoo.com", "deltacargo-deltaqa-646890", "deltacargomanuel2019@gmail.com", "delta011235813");
            var odooApi = new OdooAPI(odooCredentials);*/

            var filterTask = new object[1]
            {
                new object[]
                {
                    "id","=",taskIdErp
                }
            };
            int[] idsTask = odooAPI.Search("project.task", filterTask);
            List<XmlRpcStruct> tasksTuples = odooAPI.Read("project.task", idsTask, new object[] { })
                .ToList()
                .Cast<XmlRpcStruct>()
                .ToList();

            return tasksTuples.Find(x => ((int)x["id"]) == taskIdErp)["name"].ToString();

        }
    }
}