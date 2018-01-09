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

        public int id { get; set; }
        public int momId { get; set; }
        public Mother mom { get; set; }
       
        private string name1;

        public string name
        {
            get { return name1; }
            set { name1 = value;
          
                PropertyChanged(this, new PropertyChangedEventArgs("name")); 
             
           //     PropertyChanged(this, new PropertyChangedEventArgs("FullName"));
            }
        }

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
        private string myVar;

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
