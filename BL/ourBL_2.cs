using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL//MATANYA FUNCTIONS
{
    public partial class ourBL:IBL
    {
      //  public IEnumerable<Nanny> GetAllNannies(Mother m)
      //  {
          
      //      return dal.GetAllNannies(n=>m.timeWork[0,0]>=n.schedule[0,0] );
      //  }
      //static  public bool TermsFunc(Mother m)
      //  {
           

//}

        public IEnumerable<Child> NeedNanny()
        {
            return dal.NeedNanny();


        }
        public IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null)
        {
            return dal.GetAllContracts(predicat);
        }
        public int GetSumOfContracts(Func<Contract, bool> predicat = null)
        {
            var v= dal.GetAllContracts(predicat);
            int counter = 0;
            foreach(var item in v)
            {
                counter++;
            }
            return counter;
        }

    }
}
