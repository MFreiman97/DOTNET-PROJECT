using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Child
    {

        public int id { get; set; }
        public int momId { get; set; }
        public string name { get; set; }
        public DateTime birth { get; set; }
        public bool special { get; set; }
        public string kindSpecial { get; set; }

        public override string ToString()
        {
            return name + " ID: " + id + " Mother's ID: " + momId;
        }

    }
}
