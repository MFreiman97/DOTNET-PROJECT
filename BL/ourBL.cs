using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL//aviel functions
{
 public partial class ourBL : IBL
    {
        Idal dal; // So That I Could Use Dal's Functions

        // Add Functions
        public ourBL()
        {

            dal = new DAL.Dal_imp();

        }
        public void addChild(Child ch)
        {
            dal.addChild(ch);
        }

        public void addContract(Contract cont)
        {
            Child ch = cont.c; // Get The Child (Of The Contract)
            Nanny na = cont.n; // Get The Nanny (Of The Contract)
            if (childAge(ch) == true && nannyContracts(na) == true)
            {
                cont.distance = CalculateDistance(ch.mom.address, na.address);
                cont.SalaryPerMonth = monthSalary(cont, ch, na);
                dal.addContract(cont);
            }
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
             *  Case Check < 0 => Nanny Is More Than 18 Years
             *  Case Check = 0 => Nanny Is 18 Years
             *  Case Check > 0 => Nanny Is Less Than 18 Years            
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

        public bool nannyContracts(Nanny na)
        {
            if (na.contracts >= na.Maxkids)
                return false;
            return true;
        }

        public bool childAge(Child ch)
        {
            DateTime t = DateTime.Today; // Today's Date
            DateTime NC = ch.birth.AddMonths(3); // Add 3 Months 2 The Child's Date Of Birth (4 The Comparing)
            int check = NC.CompareTo(t);
            /* Compares:
             *  Case Check < 0 => Child Is More Than 3 Months
             *  Case Check = 0 => Child Is 3 Months
             *  Case Check > 0 => Child Is Less Than 3 Months            
            */
            if (check <= 0)
                return true;
            return false;
        }

        public int hoursAmountForWeek(Nanny na)
        {
            int sum = 0;
            for (int i = 0; i < 6; i++)
                sum += na.schedule[1, i] - na.schedule[0, i];
            return sum;
        }

        public double monthSalary(Contract cont, Child ch, Nanny na)
        {
            int count = -1; // Count The Brothers
            Mother m = dal.GetMother(ch.momId); // Get The Mother (Of The Child Of The Contract)
            IEnumerable<Child> l = dal.GetAllChildsByMother(m); // Get All His Brothers

            //Checking How Many Brothers At The Same Nanny
            foreach (Child item in l)
            {
                if (item.nannyID==na.id)
                    count++;
            }

            // Change The Salary In Accordance 2 The Child's Amount && 2 The Contract Payment Type
            if (cont.ContType == ContractType.hourly)
                cont.SalaryPerMonth = 4 * hoursAmountForWeek(na) * cont.SalaryPerHour * ((100 - count * 2) / 100);
            else
                cont.SalaryPerMonth *= (100 - count * 2) / 100;

            return cont.SalaryPerMonth;
        }

    }
}