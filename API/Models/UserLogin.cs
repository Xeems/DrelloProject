﻿namespace API.Models
{
    public class UserLogin
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public string? JwtToken { get; set; }
        public string Login { get; set; }
        public string? UserHEXColor { get; set; }
        public string Password { get; set; }
    }
}
