using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
 public   class Contract
    {
        private static int contnum = 0;
        Nanny n;
        Child c;
        public bool Meet { get; set; }
        public bool Signature { get; set; }
        public double SalaryPerHour { get; set; }
        public double SalaryPerMonth { get; set; }
        public ContractType ContType { get; set; }

        public static int ContNum
        {
            get
            {
                return contnum;
            }

        }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public override string ToString()
        {
            return "Contract: " + contnum + " ,the Nanny is: " + n + ", the child is: " + c;
        }

    }
}
