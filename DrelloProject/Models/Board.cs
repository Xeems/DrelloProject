using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public ICollection<ATask>? Tasks { get; set; }
        public ICollection<BoardRole>? Roles { get; set; }
        public ICollection<UserInBoard>? Users { get; set; }

    }
}
