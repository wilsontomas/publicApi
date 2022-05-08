using AutoMapper;
using publicApi.Dal;
using publicApi.Model.Models;
using publicApi.Model.Models.Dtos;
using publicApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Service
{
    public class userService: IUserService
    {   
        private readonly IMapper _mapper;
        private readonly DbUsuarioContext _context;
        public userService(IMapper mapper, DbUsuarioContext db) {
            _mapper = mapper;
            _context = db;
        }

       

        public async Task updatePassword(string username, string password) 
        {
            var saltBytes = new byte[50];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc.GetBytes(256));

            var usuario = _context.Usuarios.Where(x => x.userName == username)
                .SingleOrDefault();

            if (usuario != null) {
                usuario.passwordHash= hashPassword;
                usuario.passwordSalt= salt;
                _context.Update(usuario);
               await _context.SaveChangesAsync();
            }
        }

        public bool veriryPassword(string password,string hash,string salt) 
        {
            var saltBytes = Convert.FromBase64String(salt);
            var rfc = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            return Convert.ToBase64String(rfc.GetBytes(256)) == hash;
        }



    }
}
