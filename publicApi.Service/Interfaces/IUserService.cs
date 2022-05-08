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
    }
}
