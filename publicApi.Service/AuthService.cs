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
        public AuthService(IMapper mapper, DbUsuarioContext db)
        {
            _mapper = mapper;
            _context = db;
        }
        public async Task Register(usuarioDto user)
        {
            var usuarioRaw = _mapper.Map<usuario>(user);
            if (user != null)
            {
                _context.Add(usuarioRaw);
                await _context.SaveChangesAsync();
                //await updatePassword(usuarioRaw.userName, user.password);
            }
        }
    }
}
