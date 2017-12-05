using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
 public   class Nanny:IComparable
    {//
        int id;
        private string fname { get; set; }
        private string name { get; set; }
        private DateTime born;
        string cell { get; set; }
        string address { get; set; }
        bool elevator { get; set; }
        FLOORS floor;//which floor the nanny live;
        int experience { get; set; }
        int Maxkids { get; set; }
        int MinAge { get; set; }//in months!!!!
        int MaxAge { get; set; }
        bool SalaryPerHour { get; set; }
        double HourSalary { get; set; }
        double MonthSalary { get; set; }
        bool[] DaysOfWork = new bool[7];
        int[,] schedule = new int[2, 6];
        bool HolidaysByTheGOV { get; set; }
        string recom;//recommendations

        public string Fname
        {
            get
            {
                return fname;
            }

            set
            {
                fname = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public DateTime Born
        {
            get
            {
                return born;
            }

            set
            {
                born = value;
            }
        }

        public override string ToString()
        {
            return Name + " " + Fname;
        }

        public int CompareTo(object obj)
        {
            Nanny n_ = obj as Nanny;
            return id.CompareTo(n_.id);
        }
    }

}
}
