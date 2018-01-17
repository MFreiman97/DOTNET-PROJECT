using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using GoogleMapsGeocoding;

namespace BL
{
  public  partial class ourBL : IBL
    {
        Idal dal; // So That I Could Use Dal's Functions
        static Random r = new Random();
        // Add Functions
        public ourBL()
        {

            dal = new DAL.Dal_XML_imp();

        }
    public    void SetFullName(int ChildID)
        {
            Child c = GetChild(ChildID);
            Mother m = GetMother(c.momId);
            c.FullName = c.name + " " + m.lName;
            updateChild(c);

        }
        #region adding functions
        /// <summary>
        /// Adding the child to the repository
        /// </summary>
        /// <param name="ch"></param>
        public void addChild(Child ch)
        {
            dal.addChild(ch);
            SetFullName(ch.id);

        }
        /// <summary>
        /// Adding the Contract to the repository
        /// </summary>
        /// <param name="ch"></param>
        public void addContract(Contract cont)
        {
            Child ch = dal.GetChild(cont.ChildId); // Get The Child (Of The Contract)
            Nanny na = cont.n; // Get The Nanny (Of The Contract)
            if (cont.DateEnd.CompareTo(DateTime.Now) < 0)
                 new Exception("The end of the contract have to be later than the starting date");
            if (childAge(ch) == true && nannyContracts(na) == true)
            {
                     cont.distance = CalculateDistance(dal.GetMother(ch.momId).address, na.address);
            
                cont.SalaryPerMonth = monthSalary(cont, ch, na);
                cont.n.MonthSalary += cont.SalaryPerMonth;
                GetChild(cont.ChildId).nannyID = cont.n.id;//refreshing the data in the child
                cont.DateBegin = DateTime.Now;
                cont.Meet = true;
                dal.addContract(cont);

            }
        }
        /// <summary>
        /// Adding the Mother to the repository
        /// </summary>
        /// <param name="ch"></param>
        public void addMom(Mother m)
        {
            dal.addMom(m);
        }
        /// <summary>
        /// Adding the Nanny to the repository
        /// </summary>
        /// <param name="ch"></param>
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
        /// <summary>
        /// Check That The Wanted Child Is Exist & Doesn't Have Any Contract & Then Delete Him 
        /// </summary>
        /// <param name="ch"></param>
        public void deleteChild(Child ch)
        {
            if (ch == null)
                throw new Exception("The Child U Tried To Delete Wasn't Exist!");
            if (dal.GetAllContracts(item => item.ChildId == ch.id).Any())
                throw new Exception("There R Contracts Related To This Child");

            dal.deleteChild(ch);
        }

        public void deleteContract(Contract c)
        {
            if (c == null)
                throw new Exception("The Contract U Tried To Delete Wasn't Exist!");
  
            dal.deleteContract(c);

        }

        /// <summary>
        /// Check That The Wanted Mom Is Exist & Doesn't Have Any Childs & Then Delete Her 
        /// </summary>
        /// <param name="m"></param>
        public void deleteMom(Mother m)
        {
            if (m == null)
                throw new Exception("The Mother U Tried To Delete Wasn't Exist!");
            if (dal.GetAllChildsByMother(m).Any())
                throw new Exception("This Mother has Children");
            dal.deleteMom(m);
        }

        /// <summary>
        /// Check That The Wanted Nanny Is Exist & Doesn't Have Any Contracts & Then Delete Her 
        /// </summary>
        /// <param name="n"></param>
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
        /// <summary>
        /// Updating the child by overriding 
        /// </summary>
        /// <param name="c"></param>
        public void updateChild(Child c)
        {

            dal.updateChild(c);
        }
        /// <summary>
        /// Updating the Contract by overriding 
        /// </summary>
        /// <param name="c"></param>
        public void updateContract(Contract cont)
        {
            Child ch = GetChild(cont.ChildId); // Get The Child (Of The Contract)
            Nanny na = cont.n; // Get The Nanny (Of The Contract)
            if (childAge(ch) == true && nannyContracts(na) == true)
            {
                // cont.distance = CalculateDistance(ch.mom.address, na.address);
                cont.distance = 6;
                cont.SalaryPerMonth = monthSalary(cont, ch, na);
                 dal.updateContract(cont);
            }
           
        }
        /// <summary>
        /// Updating the Mother by overriding 
        /// </summary>
        /// <param name="c"></param>
        public void updateMom(Mother m)
        {
            dal.updateMom(m);
            foreach(var item in GetAllChilds())
            {
                if(item.momId==m.id)
                    SetFullName(item.id);

            }
        }
        /// <summary>
        /// Updating the Nanny by overriding . the  
        /// </summary>
        /// <param name="c"></param>
        public void updateNanny(Nanny n)
        {
          
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

        /// <summary>
        /// Calculate How Many Hours The Nanny Works In A Week
        /// </summary>
        /// <param name="na"></param>
        /// <returns></returns>
        public TimeSpan hoursAmountForWeek(Nanny na)
        {
            TimeSpan sum = na.schedule[1][ 0].Subtract(na.schedule[0][ 0]);
            for (int i = 1; i < 6; i++)
                 sum += na.schedule[1][ i].Subtract(na.schedule[0][ i]);
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

            if (cont.SalaryPerMonth == 0)//in case of best5
                cont.SalaryPerMonth = 4 * hoursAmountForWeek(na).TotalHours * na.HourSalary;

            return cont.SalaryPerMonth;
        }

    }
}