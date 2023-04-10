using System.ComponentModel.DataAnnotations.Schema;

namespace DrelloProject.Models
{
    public class UserInBoard
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<BoardRole> BoardRoles { get; set; }
        public Board Board { get; set; }
    }
}
