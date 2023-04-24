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

        public int BoardId { get; set; }
        [ForeignKey("BoardId")]
        public Board? Board { get; set; }

        public int? ExecutorUserId { get; set; }
        [ForeignKey("ExecutorUserId")]
        public User? ExecutorUser { get; set; }

        public int? RequiredRoleId { get; set; }
        [ForeignKey("RequiredRoleId")]
        public BoardRole? RequiredRole { get; set; }
    }

    public enum ATaskStatus
    {
        NotStarted,
        Performed,
        Done
    }
}
