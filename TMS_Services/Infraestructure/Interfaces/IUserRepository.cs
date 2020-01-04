using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Services.App_Data;
using TMS_Services.Models.DTO;

namespace TMS_Services.Infraestructure.Interfaces
{
    public interface IUserRepository : IRepository<usuario>
    {
        // metodos adicionales de implementacion
        UserResponseDTO logIn(UserDTO user);

        IEnumerable<ContactDTO> syncWithErp();

        IEnumerable<ContactDTO> getAllContactsErp();

        UserDTO generateFirstPassword(int userId);
        UserDTO editPrivileges(UserDTO model);



    }
}
