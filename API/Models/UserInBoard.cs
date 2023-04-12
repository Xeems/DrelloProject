using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class UserInBoard
    {
        public int Id { get; set; }
        
        public int BoardId { get; set; }
        [ForeignKey("BoardId")]
        public Board? Board { get; set; }
        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int? RoleId { get; set; }
        [ForeignKey("UserId")]
        public BoardRole? BoardRole { get; set; }
    }
}
