using publicApi.Model.Models.Dtos;
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
    }
}
