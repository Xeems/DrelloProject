﻿namespace DrelloApi.Models
{
    public class User
    { 
        public string UserName { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
