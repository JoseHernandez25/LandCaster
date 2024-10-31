using LandCaster.Entities.DTOs;
using LandCaster.Entitites.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface IAuthLogin
    {
        Task<ActionResult<AuthenticationResponse>> Login(Credentials credentials);

    }
}
