using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
  public  class Mother: IComparable 
    {

        public int id { get; set; }
       
        private string myVar;

        public string lName
        {
            get { return myVar; }
            set { myVar = value;
            
            }
        }

        public string fName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int nannyArea { get; set; }
        public bool[] needNanny = new bool[6];
        public DateTime[,] timeWork = new DateTime[2, 6];
        public string note { get; set; }

        public override string ToString()
        {
            return fName +" "+ lName + " "+id;
        }

        public int CompareTo(object obj)
        {
            Mother m = obj as Mother;
            return id.CompareTo(m.id);
        }

       public string FullName
        {
            get { return fName+" "+lName; }
         
        }

    }
}
