using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Model.Models
{
    public class Tareas
    {
        public int id { get; set; }
        public string name { get; set; }
        public string message { get; set; }

        public int usuarioId { get; set; }
        public virtual usuario usuario { get; set; }

    }
}
