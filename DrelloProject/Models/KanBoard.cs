using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.Models
{
    public class KanBoard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User>  Members { get; set; }
        public List<ATask>? Tasks { get; set; }
        public User Creator { get; set; }


    }
}
