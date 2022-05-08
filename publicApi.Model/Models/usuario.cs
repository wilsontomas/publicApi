using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Model.Models
{
    public class usuario
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public int lastName { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public string passwordSalt { get; set; }

        public virtual usuarioType usuarioTypes { get; set; }
        public int typeId { get; set; }
        public virtual List<Tareas> tareas { get; set; }
    }
}


