﻿using WebApi.Enums;

namespace WebApi.Dtos
{
    public class UserCreateDto
    {
        public string Name {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.User;

    }
}
