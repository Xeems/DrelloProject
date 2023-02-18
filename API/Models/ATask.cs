using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class ATask
    {
        public int Id { get; set; }
        public BoardRole requiredRole { get; set; }
        public string Name { get; set; }
        public ATaskStatus Status { get; set; }
        
    }

    public enum ATaskStatus
    {
        Done,
        Performed,
        NotStarted
    }
}
