using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
 public   class Nanny:IComparable
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string name { get; set; }
        public DateTime born { get; set; }
        public string cell { get; set; }
        public string address { get; set; }
        public bool elevator { get; set; }
        public FLOORS floor;//which floor the nanny live;
        public int experience { get; set; }
        public int Maxkids { get; set; }
        public int MinAge { get; set; }//in months!!!!
        public int MaxAge { get; set; }
        public bool SalaryPerHour { get; set; }
        public double HourSalary { get; set; }
        public double MonthSalary { get; set; }
        public bool[] DaysOfWork = new bool[6];
        public DateTime[,] schedule = new DateTime[2, 6];
        public bool HolidaysByTheGOV { get; set; }
        public string recom;//recommendations
        public  int contracts = 0;

        public int Contracts
        {
            get
            {
                return contracts;
            }

            set
            {
                contracts = value;
            }
        }

      

       

        public override string ToString()
        {
            return name + " " + fname;
        }

        public int CompareTo(object obj)
        {
            Nanny n_ = obj as Nanny;
            return id.CompareTo(n_.id);
        }
    }

}

