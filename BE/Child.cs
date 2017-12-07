using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Child:IComparable
    {

        public int id { get; set; }
        public int momId { get; set; }
        public Mother mom { get; set; }
        public string name { get; set; }
        public DateTime birth { get; set; }
        public bool special { get; set; }
        public string kindSpecial { get; set; }
        public int? nannyID { get; set; }

        public override string ToString()
        {
            return name + " ID: " + id + " Mother's ID: " + momId;
        }

        public int CompareTo(object obj)
        {
            return id.CompareTo(((Child)obj).id);
        }
    }
}
