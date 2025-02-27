﻿using WebApi.Enums;

namespace WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash {  get; set; }
        public Role Role { get; set; } = Role.User;
        

        public ICollection<Order> Orders {  get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
