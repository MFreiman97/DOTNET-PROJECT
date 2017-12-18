using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
 public partial class ourBL : IBL
    {
        Idal dal; // So That I Could Use Dal's Functions

        // Add Functions
        public ourBL()
        {

            dal = new DAL.Dal_imp();

        }
        #region adding functions
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
                //     cont.distance = CalculateDistance(ch.mom.address, na.address);
                cont.distance = 6;//****************************************
                cont.SalaryPerMonth = monthSalary(cont, ch, na);
                cont.c.nannyID = cont.n.id;//refreshing the data in the child
                cont.DateBegin = DateTime.Now;
                cont.Meet = true;
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
            DateTime y = n.born.AddYears(18); // Add 18 Years 2 The Nanny's Date Of Birth (4 The Comparing)
            int check = y.CompareTo(t);
            /* Compares:
             *  Case Check < 0 => Nanny Is More Than 18 Years
             *  Case Check = 0 => Nanny Is 18 Years
             *  Case Check > 0 => Nanny Is Less Than 18 Years            
            */
            if (check <= 0)
                dal.addNanny(n);
           
        }
        #endregion
        #region delete functions
        public void deleteChild(Child ch)
        {
            if (ch == null)
                throw new Exception("The Child U Tried To Delete Wasn't Exist!");
            if (dal.GetAllContracts(item => item.c.id == ch.id).Any())
                throw new Exception("There R Contracts Related To This Child");

            dal.deleteChild(ch);
        }

        public void deleteContract(Contract c)
        {
            if (c == null)
                throw new Exception("The Contract U Tried To Delete Wasn't Exist!");
            dal.deleteContract(c);
        }

        public void deleteMom(Mother m)
        {
            if (m == null)
                throw new Exception("The Mother U Tried To Delete Wasn't Exist!");
            if (dal.GetAllChildsByMother(m).Any())
                throw new Exception("This Mother has Children");
            dal.deleteMom(m);
        }

        public void deleteNanny(Nanny n)
        {
            if (n == null)
                throw new Exception("the Nanny you tried to delete wasn't exist!");
            if (n.contracts > 0)
                throw new Exception("There R Contracts Related To This Nanny");

            dal.deleteNanny(n);
        }
        #endregion
        #region Update functions
        public void updateChild(Child c)
        {

            dal.updateChild(c);
        }

        public void updateContract(Contract cont)
        {
            Child ch = cont.c; // Get The Child (Of The Contract)
            Nanny na = cont.n; // Get The Nanny (Of The Contract)
            if (childAge(ch) == true && nannyContracts(na) == true)
            {
                // cont.distance = CalculateDistance(ch.mom.address, na.address);
                cont.distance = 6;
                cont.SalaryPerMonth = monthSalary(cont, ch, na);
                 dal.updateContract(cont);
            }
           
        }

        public void updateMom(Mother m)
        {
            dal.updateMom(m);
        }

        public void updateNanny(Nanny n)
        {
            DateTime t = DateTime.Today; // Today's Date
            DateTime y = n.born.AddYears(18); // Add 18 Years 2 The Nanny's Date Of Birth (4 The Comparing)
            int check = y.CompareTo(t);
            /* Compares:
             *  Case Check < 0 => Nanny Is More Than 18 Years
             *  Case Check = 0 => Nanny Is 18 Years
             *  Case Check > 0 => Nanny Is Less Than 18 Years            
            */
            if (check <= 0)
                dal.updateNanny(n);
        }


        #endregion





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
        public TimeSpan hoursAmountForWeek(Nanny na)
        {
            TimeSpan sum = na.schedule[1, 0].Subtract(na.schedule[0, 0]);
            for (int i = 1; i < 6; i++)
                 sum += na.schedule[1, i].Subtract(na.schedule[0, i]);
            return (sum);
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
                cont.SalaryPerMonth = 4 * hoursAmountForWeek(na).TotalHours * na.HourSalary * ((100 - count * 2) / 100);
            else
                cont.SalaryPerMonth = na.MonthSalary * (100 - count * 2) / 100;

            return cont.SalaryPerMonth;
        }

    }
}