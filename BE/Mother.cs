using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
  public  class Mother: IComparable ,INotifyPropertyChanged
    {

 
        private int id_;

        public int id
        {
            get { return id_; }
            set {
                 int x;
                if (int.TryParse(value.ToString(),out x)==false)
                {

                    throw new Exception("ERROR - Enter Only DIGITS Please!");
                  }
                else
                id_ = value;
            }
        }

    
        private string lname_  ;

        public string lName
        {
            get { return lname_; }
            set {
                if (value.Any(char.IsDigit))
                {

                    throw new Exception("ERROR - Enter Only Chars Please!");
                }
                else
                {
                    lname_ = value;
                    if (PropertyChanged != null)//neccesary!!!
                        PropertyChanged(this, new PropertyChangedEventArgs("FullName"));
                }
            }
        }
         public event PropertyChangedEventHandler PropertyChanged;
     
        private string fname_;

        public string fName
        {
            get { return fname_; }
            set {

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

    
        private string phone_;

        public string phone
        {
            get { return phone_; }
            set {

               if(value.Any(char.IsLetter))
                    throw new Exception("ERROR - Enter Only Numbers Please!");
              else if(value.Count()!=10)
                    throw new Exception("ERROR - The Phone number have to contain 10 digits!");
               else
                phone_ = value; }
        }

        public string address { get; set; }
     
        private int nannyArea_;
      
        public int nannyArea
        {
            get { return nannyArea_; }
            set {
                if (value.ToString().Any(char.IsLetter)==true)
                    throw new Exception("ERROR - Enter Only numbers Please!");
                else
                nannyArea_ = value; }
        }

        public bool[] needNanny = new bool[6];
        public TimeSpan[][] timeWork = new TimeSpan[2][];
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
        public Mother()
        {
            for(int i=0; i<2;i++)
            {
                timeWork[i] = new TimeSpan[6];
            }
        }
    }
}
