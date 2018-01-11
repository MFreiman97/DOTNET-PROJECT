using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Child:IComparable, INotifyPropertyChanged
    {

        private int id_;

        public int id
        {
            get { return id_; }
            set
            {
                int x;
                if (int.TryParse(value.ToString(),out x)==false)
                {

                    throw new Exception("ERROR - Enter Only DIGITS Please!");
                }
                else
                id_ = value; }
        }

        public int momId { get; set; }
        public Mother mom { get; set; }
       
        private string name1;

        public string name
        {
            get { return name1; }
            set {

                if (value.Any(char.IsDigit))
                {

                    throw new Exception("ERROR - Enter Only Chars Please!");
                }
                else
                {
                    name1 = value;

                    PropertyChanged(this, new PropertyChangedEventArgs("FullName"));
                }
            }
        }

     
        private DateTime birth_;

        public DateTime birth
        {
            get { return birth_; }
            set {
                if (value.Ticks>DateTime.Now.Ticks)
                {

                    throw new Exception("The birth Have to be earlier than today");
                }
                else
                {
                    birth_ = value;

              
                }

        }
        }

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
        
        public event PropertyChangedEventHandler PropertyChanged;

        public string FullName
        {
            get { return name+ " "+mom.lName; }
        
        }
        //protected void OnPropertyChanged(string name)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(name));
        //    }
        //}




    }
}
