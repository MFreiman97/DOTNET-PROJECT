using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Mother
    {

        public int id { get; set; }
        public string lName { get; set; }
        public string fName { get; set; }
        public int phone { get; set; }
        public string address { get; set; }
        public string nannyArea { get; set; }
        public bool[] needNanny = new bool[6];
        public int[,] timeWork = new int[2, 6];
        public string note { get; set; }

        public override string ToString()
        {
            return fName + lName + " Phone Number: " + phone;
        }
    }
}
