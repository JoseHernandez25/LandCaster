using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class AuthenticationResponse
    {
        public User User { get; set; }

        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        //public DateTime Expiration { get; set; }

        //public bool Success { get; set; }
        public string Message { get; set; }



    }
}
