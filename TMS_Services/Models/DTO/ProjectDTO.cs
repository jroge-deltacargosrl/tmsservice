using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.DTO
{
    // refactorizar esta clase
    public class ProjectDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<StageDTO> stages { get; set; } = new List<StageDTO>();


        // override object.Equals
        public override bool Equals(object obj)
        {
           
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var other = (ProjectDTO)obj;
            return id == other.id;            
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode()*name.Length;
        }







    }
}