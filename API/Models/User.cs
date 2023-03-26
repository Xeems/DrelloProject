using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string Login { get; set; }
        public string UserHEXColor { get; set; } = "#ffffff";
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }       
    }
}
