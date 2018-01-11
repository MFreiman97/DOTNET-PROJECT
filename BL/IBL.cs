
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  interface IBL
    {
        void addNanny(Nanny n);
        void deleteNanny(Nanny n);
        void updateNanny(Nanny n);//update the details of a nanny .i assume that the comparapble paramater is the id.

        /// <summary>
        /// Mom's Functions
        /// </summary>
        /// <param name="m"></param>
        void addMom(Mother m);
        void deleteMom(Mother m);
        void updateMom(Mother m);//i assume that the comparapble paramater is the id.

        /// <summary>
        /// Child's Functions
        /// </summary>
        /// <param name="c"></param>
        void addChild(Child c);
        void deleteChild(Child c);
        void updateChild(Child c);//.i assume that the comparapble paramater is the id.

        /// <summary>
        /// Contract's Functions
        /// </summary>
        /// <param name="c"></param>
        /// 
        Mother GetMother(int id);
        Nanny GetNanny(int id);
        Child GetChild(int id);
        void addContract(Contract c);
        void deleteContract(Contract c);
        void updateContract(Contract c);
        Contract GetContract(int cont);
        IEnumerable<Child> NeedNanny();
        IEnumerable<Child> GetAllChilds();
        IEnumerable<Child> GetSpecialChilds();
        IEnumerable<Nanny> GetAllMatchedNannies(Mother m, Child c, bool salary);
        IEnumerable<Nanny> GetAllNanniesByTerm(Mother m);
        IEnumerable<Nanny> GetAllNannies();
        IEnumerable<Nanny> TheBestFive(Mother m);//get a term that the mother can conpromise on and return the best 5
        IEnumerable<Nanny> WorkingByTheGov();
        IEnumerable<Mother> GetAllMothers();
        IEnumerable<Mother> GetAllMothersFromJerusalem();
        IEnumerable<Nanny> GetAllNanniesFromJerusalem();
        IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null);
        int GetSumOfContracts(Func<Contract, bool> predicat = null);
         IEnumerable<IGrouping<string, Nanny>> NannyGroupByExperience();
        IEnumerable<IGrouping<string, Child>> ChildsGroupBySpecial();
        IEnumerable<IGrouping<int, Nanny>> GroupOfNannies(bool sorted);
        int GetNumOfContracts(object obj);
        IEnumerable<IGrouping<string, Contract>> GroupOfSortedContract();//sorted by the distances that i divided to types in sting



    }
}
