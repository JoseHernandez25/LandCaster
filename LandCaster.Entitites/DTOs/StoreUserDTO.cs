using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class StoreUserDTO
    {
        public int roleId { get; set; }
        public string userName { get; set; }
        public string? normalizedUserName { get; set; }
        public string? email { get; set; }
        public string? normalizedEmail { get; set; }
        public string? emailConfirmed { get; set; }
        public string? passwordHash { get; set; }
        public string? phoneNumberConfirmed { get; set; }
        public string? twoFactorEnabled { get; set; }
        public string? lockoutEnabled { get; set; }
        public string? accessFailedCount { get; set; }
        public string? profilePhoto { get; set; }
        public string? createdAt { get; set; }
        public string? updatedAt { get; set; }
        public string? deletedAt { get; set; }


    }
}
