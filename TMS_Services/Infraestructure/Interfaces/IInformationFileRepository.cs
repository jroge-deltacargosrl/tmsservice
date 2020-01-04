using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Interfaces
{
    public interface IInformationFileRepository :  IRepository<InfoArchivo>
    {
        // metodos adicionales
        /*IEnumerable<InformationFileDTO> getByProjectId(int projectId);

        InformationFileDTO getByProjectTaskId(int projectId, int taskId);*/

        InfoArchivo deleteByProjectTaskId(int projectId, int taskId);

        FileUploadResponseDTO createFile(FileDTO file);

        FileUploadResponseDTO deleteFile(string fileName);

        List<string> getAllFiles();

    }
}