using AutoMapper;
using Microsoft.EntityFrameworkCore;
using publicApi.Dal;
using publicApi.Model.Models;
using publicApi.Model.Models.Dtos;
using publicApi.Service.Interfaces;
using publicApi.Service.UtilClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace publicApi.Service
{
    public class AuthService: IAuthService
    {
        private readonly IMapper _mapper;
        private readonly DbUsuarioContext _context;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthService(IMapper mapper, IUserService userService,IJwtService jwtService, DbUsuarioContext db)
        {
            _mapper = mapper;
            _context = db;
            _userService = userService;
            _jwtService = jwtService;
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
                
                
            
        }

        public async Task<JwtAuthResult> Authenticate(string username, string password)
        {
            //var usuarioRaw = _mapper.Map<usuario>(user);
            JwtAuthResult token = null;

            var usuario = _context.Usuarios.Include(x=>x.usuarioTypes)
                .Where(x => x.userName == username)
                    .ToList().SingleOrDefault();

            if (usuario != null && _userService.veriryPassword(password, usuario.passwordHash, usuario.passwordSalt))
            {
                var roles = JsonSerializer.Serialize(usuario.usuarioTypes.id);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.userName),
                    new Claim(ClaimTypes.Role, roles),
                    new Claim(ClaimTypes.Email, usuario.email)
                };

                token = await _jwtService.GenerateTokens(usuario.userName, claims.ToArray(), DateTime.UtcNow);

            }
            
                return token;
            
            
           
        }


    }
}
