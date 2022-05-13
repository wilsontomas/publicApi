using publicApi.Model.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Service.Interfaces
{
    public interface IUserService
    {
        Task updatePassword(string username, string password);
        bool veriryPassword(string password, string hash, string salt);
        Task<usuarioDto> getUserInfo(string username);
        Task UpdateUser(usuarioDto user);
        Task<List<usuarioDto>> getAllUsers();
    }
}
