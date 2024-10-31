using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class AuthenticationResponseWF
    {
        public User User { get; set; }
        public string message { get; set; }
    }
}
