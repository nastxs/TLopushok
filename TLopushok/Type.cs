using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLopushok
{
    public class Type
    {
        public int ID { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return string.Format("name", name);
        }

    }
}
