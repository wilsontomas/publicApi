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
using Microsoft.EntityFrameworkCore;


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


        public  async Task<usuarioDto> getUserInfo(int id) 
        {
            var usuario = await _context.Usuarios.Where(x => x.id==id).SingleOrDefaultAsync();
            var usuarioDto = _mapper.Map<usuarioDto>(usuario);
            return usuarioDto;
        }

        public async Task<List<usuarioDto>> getAllUsers() 
        {
            var listado = await _context.Usuarios.ToListAsync();
           var userList = _mapper.Map<List<usuarioDto>>(listado);
            return userList;
        }
        public async Task UpdateUser(usuarioDto user)
        {
            var usuario = _mapper.Map<usuario>(user);

             _context.Usuarios.Update(usuario);
              await _context.SaveChangesAsync();

           await updatePassword(user.userName, user.password);
           
        }
        public async Task DeleteUser(int id)
        {
            var usuario = await _context.Usuarios.Where(x => x.id == id).SingleOrDefaultAsync();
            if (usuario.typeId != 2) 
            {
                //delete user tasks
                var listaTareas = await _context.Tareas.Where(x => x.usuarioId == id).ToListAsync();
                _context.Tareas.RemoveRange(listaTareas);
               await _context.SaveChangesAsync();
                //delete user
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
           
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
