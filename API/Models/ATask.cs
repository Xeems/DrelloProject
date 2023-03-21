using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class ATask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ATaskStatus Status { get; set; }

        public int? RequiredRoleId { get; set; }
        [ForeignKey("RequiredRoleId")]
        public virtual BoardRole RequiredRole { get; set; }
    }

    public enum ATaskStatus
    {
        Done,
        Performed,
        NotStarted
    }
}
