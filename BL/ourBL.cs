using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL//aviel functions
{
 public partial class ourBL : IBL
    {
        DAL.Idal dal; // So That I Could Use Dal's Functions

        // Add Functions
        public void addChild(Child c)
        {
            dal.addChild(c);
        }

        public void addContract(Contract c)
        {
            
        }

        public void addMom(Mother m)
        {
            dal.addMom(m);
        }

        public void addNanny(Nanny n)
        {
            DateTime t = DateTime.Today; // Today's Date
            DateTime y = n.Born.AddYears(18); // Add 18 Years 2 The Nanny's Date Of Birth (4 The Comparing)
            int check = y.CompareTo(t);
            /* Compares:
             *  Case Check < 0 => Nanny Is More Than 18
             *  Case Check = 0 => Nanny Is 18
             *  Case Check > 0 => Nanny Is Less Than 18            
            */
            if (check <= 0)
                dal.addNanny(n);
        }

        // Delete Functions
        public void deleteChild(Child c)
        {
            dal.deleteChild(c);
        }

        public void deleteContract(Contract c)
        {
            dal.deleteContract(c);
        }

        public void deleteMom(Mother m)
        {
            dal.deleteMom(m);
        }

        public void deleteNanny(Nanny n)
        {
            dal.deleteNanny(n);
        }

        // Update Functions
        public void updateChild(Child c)
        {
            dal.updateChild(c);
        }

        public void updateContract(Contract c)
        {
            dal.updateContract(c);
        }

        public void updateMom(Mother m)
        {
            dal.updateMom(m);
        }

        public void updateNanny(Nanny n)
        {
            dal.updateNanny(n);
        }
    }
}