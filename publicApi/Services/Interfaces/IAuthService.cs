using publicApi.Model.Models;
using publicApi.Model.Models.Dtos;
using publicApi.Service.UtilClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Service.Interfaces
{
    public interface IAuthService
    {
        Task Register(usuarioDto user);
        Task<JwtAuthResult> Authenticate(string username, string password);
    }
}
