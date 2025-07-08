using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI_Mikrotik
{
    using System.ComponentModel.DataAnnotations;

    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;
        public string ipAddress { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

}
