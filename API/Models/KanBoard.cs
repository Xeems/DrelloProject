using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class KanBoard
    {
        public int KanBoardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User>? Members { get; set; }
        public ICollection<ATask>? Tasks { get; set; }
        public int CreatorId { get; set; }


    }
}
