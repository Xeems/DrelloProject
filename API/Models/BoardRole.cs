using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class BoardRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BoardId { get; set; }
        [ForeignKey("BoardId")]
        public Board? Board { get; set; }
        public string? RoleHEXColor { get; set; }
    }
}
