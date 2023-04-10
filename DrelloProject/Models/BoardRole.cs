using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.Models
{
    public class BoardRole
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public Board? Board { get; set; }
        public string Name { get; set; }
        public ICollection<UserInBoard>? Users { get; set; }

    }
}
