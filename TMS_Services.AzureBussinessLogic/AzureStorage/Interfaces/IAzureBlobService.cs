using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Services.AzureBussinessLogic.AzureStorage.Interfaces
{
    public interface IAzureBlobService
    {
        Task<IEnumerable<Uri>> listAsync();
        Task uploadAsync(IFormFileCollection files);
        Task deleteAsync(string fileUri);
        Task deleteAllAsync();
    }
}
