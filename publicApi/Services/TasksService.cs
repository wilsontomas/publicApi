using Microsoft.EntityFrameworkCore;
using publicApi.Dal;
using publicApi.Model.Models;
using publicApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;


namespace publicApi.Services
{
    public class TasksService: ITaskService
    {
        
        private readonly DbUsuarioContext _context;
       

        public TasksService(DbUsuarioContext db)
        {
            _context = db;
        }
        public async Task<List<Tareas>> GetTareas(int userid) {
            var listado = await _context.Tareas.Where(x => x.usuarioId == userid).ToListAsync();
            return listado;
        }

        public async Task<Tareas> GetTareaById(int id)
        {
            var tarea = await _context.Tareas.Where(x => x.id == id).SingleOrDefaultAsync();
            return tarea;
        }

        public async Task updateTarea(Tareas tarea) 
        {
            _context.Tareas.Update(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task addTarea(Tareas tarea) 
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }
    }
}
