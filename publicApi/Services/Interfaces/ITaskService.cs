using publicApi.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace publicApi.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<Tareas>> GetTareas(int userid);
        Task<Tareas> GetTareaById(int id);
        Task updateTarea(Tareas tarea);
        Task addTarea(Tareas tarea);
    }
}
