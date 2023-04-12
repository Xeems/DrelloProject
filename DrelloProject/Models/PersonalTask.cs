using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.Models
{
    public class PersonalTask
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Task { get; set; }
        public bool IsCompleted { get; set; }
    }
}
