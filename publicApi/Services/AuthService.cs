using AutoMapper;
using publicApi.Dal;
using publicApi.Model.Models;
using publicApi.Model.Models.Dtos;
using publicApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Service
{
    public class AuthService: IAuthService
    {
        private readonly IMapper _mapper;
        private readonly DbUsuarioContext _context;
        private readonly IUserService _userService;
        public AuthService(IMapper mapper, IUserService userService, DbUsuarioContext db)
        {
            _mapper = mapper;
            _context = db;
            _userService = userService;
        }
        public async Task Register(usuarioDto user)
        {
            var usuarioRaw = _mapper.Map<usuario>(user);
            try
            {
                _context.Add(usuarioRaw);
                await _context.SaveChangesAsync();
                await _userService.updatePassword(usuarioRaw.userName, user.password);
            }
            catch (Exception er) 
            {
                return;
            }
                
                //
            
        }

        public bool Authenticate(string username, string password)
        {
            //var usuarioRaw = _mapper.Map<usuario>(user);
            
              var usuario = _context.Usuarios.Where(x => x.userName == username)
                    .ToList().SingleOrDefault();

            if (usuario != null)
            {
                return _userService.veriryPassword(password, usuario.passwordHash, usuario.passwordSalt);
            }
            else {
                return false;
            } 
            
           
        }


    }
}
