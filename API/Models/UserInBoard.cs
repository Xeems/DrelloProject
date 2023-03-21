using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class UserInBoard
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        [ForeignKey("BoardId")]
        public virtual Board Board { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public ICollection<BoardRole>? BoardRoles { get; set; }
    }
}
