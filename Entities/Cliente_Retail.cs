using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cliente_Retail
    {
        public int Cl_Ret_IDdb { get; set; }
        public int Cl_Ret_CODE { get; set; }
        public string Cl_Ret_Name { get; set; }
        public string Cl_Ret_Surname { get; set; }
        public string Cl_Ret_Nickname { get; set; }
        public int Cl_Ret_Tot { get; set; }
        public int Cl_Ret_Act { get; set; }
        public string Cl_Ret_Comment { get; set; }
        public Cliente_Retail() { }
    }
}
