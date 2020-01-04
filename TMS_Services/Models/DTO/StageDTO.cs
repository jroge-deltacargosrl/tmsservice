using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS_Services.Models.DTO
{
    public class StageDTO:  IComparable<StageDTO>
    {
        public int id { get; set; }
        public string name { get; set; }
        public int sequence { get; set; }
        public int projectId { get; set; }

        // adecuacion: etapa contiene muchas tareas
        public List<TaskDTO> tasks { get; set; } = new List<TaskDTO>();

        


        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var other = (StageDTO)obj;
            return id == other.id;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode()*name.Length;
        }

        public int CompareTo(StageDTO other) => sequence.CompareTo(other.sequence);
        

    }
}