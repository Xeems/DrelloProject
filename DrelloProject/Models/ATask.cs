using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.Models
{
    public class ATask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BoardId { get; set; }
        public int RequiredRoleId { get; set; }
        public int? ExecutorUserId { get; set; }
        public Board? Board { get; set; }
        public BoardRole? RequiredRole { get; set; }
        public User? ExecutorUser { get; set; }
        public ATaskStatus Status { get; set; }
        
    }

    public enum ATaskStatus
    {
        NotStarted,
        Performed,
        Done
                       
    }
}
