using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
 public   class Contract:IComparable
    {
   public  int contnum { get; set; }
        public Nanny n { get; set; }
        public Child c { get; set; }
        public bool Meet { get; set; }
        public bool Signature { get; set; }
        public double SalaryPerHour { get; set; }
        public double SalaryPerMonth { get; set; }
        public ContractType ContType { get; set; }

       
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public override string ToString()
        {
            return "Contract: " + contnum + " ,the Nanny is: " + n + ", the child is: " + c;
        }

        public int CompareTo(object obj)
        {
            Contract co = obj as Contract;
            return contnum.CompareTo(co.contnum);
        }
    }
}
