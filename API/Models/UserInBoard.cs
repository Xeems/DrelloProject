namespace API.Models
{
    public class UserInBoard
    {
        public int Id { get; set; }
        public User User { get; set; }
        public KanBoard Board { get; set; }
        public BoardRole BoardRole { get; set; }
    }
}
