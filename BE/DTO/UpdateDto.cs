using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.DTO
{
    public class UpdateDto
    
    {
        public UpdateDto(string newdata, int dni, string type)
        {
            Newdata = newdata;
            Dni = dni;
            Type = type;
        }
        public string Newdata { get; set; } = string.Empty;

        public int Dni { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
