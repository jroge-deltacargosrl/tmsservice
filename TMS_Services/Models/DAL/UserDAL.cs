using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TMS_Services.App_Data;
using TMS_Services.App_Utils;
using TMS_Services.Infraestructure.Interfaces;
using TMS_Services.Models.DTO;
using TMS_Services.Models.ViewModels;
using static TMS_Services.App_Utils.UtilsApiTms;


namespace TMS_Services.Models.DAL
{
    public class UserDAL
    {
        // Modificar esta clase para aplicar el patron repositorio
        private readonly IUserRepository userRepository;
       
        public UserDAL(IUserRepository userRepository, MailServiceDAL mailServiceDAL)
        {
            this.userRepository = userRepository;
            
        }

        public UserDTO getById(int id)
        {
            return (UserDTO)userRepository.getById(id);
        }


        public List<UserDTO> getAll(Expression<Func<usuario, bool>> filter = null, Func<IQueryable<usuario>, IOrderedQueryable<usuario>> orderBy = null)
        {
            return userRepository.get()
                .ToList()
                .ConvertAll(u => (UserDTO)u);
        }


        public UserDTO create(UserDTO user)
        {
            return (UserDTO)userRepository.create(user);
        }

        public UserDTO update(UserDTO model)
        {
            // obtener el objeto de la base de datos y actualizarlo
            return (UserDTO)userRepository.edit(model);
        }

        public UserDTO updatePrivileges(UserDTO model)
        {
            return userRepository.editPrivileges(model);
        }

        // provisionalmente se guardara en la base de datos EntityFramework
        /*public UserDTO generateFirstPassword(UserDTO model)
        {
            
            /*using (DeltaDBEntities db = new DeltaDBEntities())
            {
                // generar la nueva constraseña para el usuario
                model.password = RandomPassword.randomPassword(acceptToUpper:true);
                db.Entry<usuario>(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                // enviar la notificacion la nueva contraseña al usuario
                return (UserDTO)db.usuario.Find(model.id);
            }
        }*/

        public UserDTO generateFirstPassword(int userId)
        {
            return userRepository.generateFirstPassword(userId);
        }
      

        public UserDTO delete(int id)
        {
            return (UserDTO)userRepository.remove(id);
        }

        public IEnumerable<UserDTO> deleteAll()
        {
            return userRepository.removeAll()
                .ToList()
                .ConvertAll(u => (UserDTO)u);
        }

        

        // Metodos adicionales
        public UserResponseDTO logIn(UserDTO user)
        {
            return userRepository.logIn(user);
        }

        
    }
}