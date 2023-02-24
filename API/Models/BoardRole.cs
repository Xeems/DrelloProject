using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class BoardRole
    {

        public int Id { get; set; }
        public int BoardId { get; set; }
        public string Name { get; set; }

    }
}
