using System;//matanya
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
 public   class Contract:IComparable
    {
        private int Contnum;
        public Nanny n { get; set; }
        public Child c { get; set; }
        public bool Meet { get; set; }
        public bool Signature { get; set; }
        public double SalaryPerHour { get; set; }
        public double SalaryPerMonth { get; set; }
        public ContractType ContType { get; set; }

       
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int distance { get; set; }

        public int contnum
        {
            get
            {
                return Contnum;
            }

            set
            {
                Contnum = value;
            }
        }

        public override string ToString()
        {
            //string str=format
            return "Contract: " +string.Format("{0:00000000}",contnum)  ;
        }

        public int CompareTo(object obj)
        {
            Contract co = obj as Contract;
            return contnum.CompareTo(co.contnum);
        }
    }
}
