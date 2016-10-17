using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05省市联动
{
    public class contentinfo
    {
        public int dId { get; set; }
        public string dName { get; set; }
        //public string dContent { get; set; }
        public override string ToString()
        {
            return this.dName;
        }
    }
}
