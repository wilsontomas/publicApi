using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Model.Models
{
    public class usuarioType
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<usuario> usuarios { get; set; }
    }
}
