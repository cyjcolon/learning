using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05省市联动
{
    public class Province_City
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string PCode { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
