using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05省市联动
{
    public class Category
    {
        public int tId { get; set; }
        public string tName { get; set; }
        public int tParentId { get; set; }
        public string tNote { get; set; }
    }
}
