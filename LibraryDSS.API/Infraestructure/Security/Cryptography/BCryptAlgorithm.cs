﻿using LibraryDSS.API.Domain.Entities;
using System.Globalization;

namespace LibraryDSS.API.Infraestructure.Security.Cryptography
{
    public class BCryptAlgorithm
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public bool Verify(string password, User user) => BCrypt.Net.BCrypt.Verify(password, user.Password);
    }
}
