using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Model.Models.Dtos
{
    public class usuarioDto
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public int lastName { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public int typeId { get; set; }

        public string password { get; set; }
    }
}
