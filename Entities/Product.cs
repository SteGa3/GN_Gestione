using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int ID_Product { get; set; }

        public string Name_Product { get; set; }
        public List<int> PackQ_Product { get; set; }
        public int UnitsAv_Product { get; set; }
        public Product() { }
    }
}
