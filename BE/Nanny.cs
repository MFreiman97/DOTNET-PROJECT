using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
 public   class Nanny:IComparable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int id_;
        public int id
        {
            get { return id_; }
            set
            {
                int x;
                if (int.TryParse(value.ToString(), out x) == false)
                {

                    throw new Exception("ERROR - Enter Only DIGITS Please!");
                }
                else
                    id_ = value;
            }
        }
        private string fname_;
        public string fname
        {
            get { return fname_; }
            set
            {

                if (value.Any(char.IsDigit))
                {

                    throw new Exception("ERROR - Enter Only Chars Please!");
                }
                else
                {
                    fname_ = value;

                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("FullName"));
                }
            }
        }
        public double co1 { get; set; }
        public double co2 { get; set; }
        private string name_;

        public string name
        {
            get { return name_; }
            set
            {

                if (value.Any(char.IsDigit))
                {

                    throw new Exception("ERROR - Enter Only Chars Please!");
                }
                else
                {
                    name_ = value;

                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("FullName"));
                }
            }
        }
   
        private DateTime born_;

        public DateTime born
        {
            get { return born_; }
            set {
                if (value.Year < 1950 || value.Ticks > DateTime.Now.Ticks)
                    throw new Exception("Error-The Date is Wrong!!!");
                else
                born_ = value; }
        }

        private string cell_;

        public string cell
        {
            get { return cell_; }
            set
            {

                if (value.Any(char.IsLetter))
                    throw new Exception("ERROR - Enter Only Numbers Please!");
                else if (value.Count() != 10)
                    throw new Exception("ERROR - The Phone number have to contain 10 digits!");
                else
                    cell_ = value;
            }
        }
        public string address { get; set; }
        public bool elevator { get; set; }
        public FLOORS floor;//which floor the nanny live;
        private int experience_;
        public int experience
        {
            get { return experience_; }
            set
            {
                int x;
                if (int.TryParse(value.ToString(), out x) == false)
                {

                    throw new Exception("ERROR - Enter Only DIGITS Please!");
                }
                if (value<0)
                {

                    throw new Exception("ERROR - Enter Only positive numbers Please!");
                }
                else
                    experience_ = value;
            }
        }
    
        private int MaxKids_;

        public int Maxkids
        {
            get { return MaxKids_; }
            set {
                if (value.ToString().Any(char.IsLetter))
                    throw new Exception("ERROR - Enter Only DIGITS Please!");
                if(value<0)
                    throw new Exception("ERROR - The maximum kids have to be Positive!");
          
                MaxKids_ = value; }
        }//in months!!!!

     
        private int MinAge_;

        public int MinAge
        {
            get { return MinAge_; }
            set {if (value < 0)
                    throw new Exception("Error-The Age Have to Be positive!!");
                if (value.ToString().Any(char.IsLetter))
                    throw new Exception("Error-enter only numbers!!");
                MinAge_ = value; }
        }

      
        private int MaxAge_;

        public int MaxAge
        {
            get { return MaxAge_; }
            set {if(value<MinAge)
                    throw new Exception("Error-The Age Have to Be bigger than the minimum positive!!");
                if (value.ToString().Any(char.IsLetter))
                    throw new Exception("Error-enter only numbers!!");
                MaxAge_ = value; }
        }

        public bool SalaryPerHour { get; set; }
        public double HourSalary { get; set; }
        public double MonthSalary { get; set; }
        public bool[] DaysOfWork = new bool[6];
        public TimeSpan[][] schedule = new TimeSpan[2][];
        public bool HolidaysByTheGOV { get; set; }
        public string recom;//recommendations
        public  int contracts = 0;
        private string fullname;

        public string FullName
        {
            get { return fname + " " + name;  }
         
        }

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
            return name + " " + fname +" her ID is: "+id;
        }

        public int CompareTo(object obj)
        {
            Nanny n_ = obj as Nanny;
            return id.CompareTo(n_.id);
        }
        public Nanny()
        {
            for (int i = 0; i < 2; i++)
            {
                schedule[i] = new TimeSpan[6];
            }
        }
    }

}

