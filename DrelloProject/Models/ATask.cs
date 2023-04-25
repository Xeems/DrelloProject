using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        
        [JsonIgnore]
        public bool? IsAvailable { get; set; } = false;
        
    }

    public enum ATaskStatus
    {
        NotStarted,
        Performed,
        Done
                       
    }
}
