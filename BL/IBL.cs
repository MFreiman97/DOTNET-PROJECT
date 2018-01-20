
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  interface IBL
    {/// <summary>
    /// Add Nanny to the repository
    /// </summary>
    /// <param name="n"></param>
        void addNanny(Nanny n);
        /// <summary>
        /// delete nanny from the repoistory
        /// </summary>
        /// <param name="n"></param>
        void deleteNanny(Nanny n);
        /// <summary>
        /// update the nanny in the repository
        /// </summary>
        /// <param name="n"></param>
        void updateNanny(Nanny n);//update the details of a nanny .i assume that the comparapble paramater is the id.

    /// <summary>
    /// Add mother to the repository
    /// </summary>
    /// <param name="m"></param>
        void addMom(Mother m);
        /// <summary>
        /// delete Mother from the repository
        /// </summary>
        /// <param name="m"></param>
        void deleteMom(Mother m);
        /// <summary>
        /// Update Mother in the repository
        /// </summary>
        /// <param name="m"></param>
        void updateMom(Mother m);//i assume that the comparapble paramater is the id.

      /// <summary>
      /// Add child to the repository
      /// </summary>
      /// <param name="c"></param>
        void addChild(Child c);
        /// <summary>
        /// delete child from the repository
        /// </summary>
        /// <param name="c"></param>
        void deleteChild(Child c);
        /// <summary>
        /// update child in the repository
        /// </summary>
        /// <param name="c"></param>
        void updateChild(Child c);//.i assume that the comparapble paramater is the id.

     
        /// <summary>
        /// The function return a mother by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Mother GetMother(int id);
        /// <summary>
        /// This Function return the nanny by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Nanny GetNanny(int id);
        /// <summary>
        /// This function return the child by his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Child GetChild(int id);
        /// <summary>
        /// This Function adding the contract to the repository
        /// </summary>
        /// <param name="c"></param>
        void addContract(Contract c);

        /// <summary>
        /// This function delete the contract from the repository
        /// </summary>
        /// <param name="c"></param>
        void deleteContract(Contract c);
        /// <summary>
        /// This function updating the contract in the repository
        /// </summary>
        /// <param name="c"></param>
        void updateContract(Contract c);
        /// <summary>
        /// This function return the contract by the contnum variable
        /// </summary>
        /// <param name="cont"></param>
        /// <returns></returns>
        Contract GetContract(int cont);
        /// <summary>
        /// This function return ienumerable of the childs that need nanny
        /// </summary>
        /// <returns></returns>
        IEnumerable<Child> NeedNanny();
        /// <summary>
        /// This function return enumerable of all the childs
        /// </summary>
        /// <returns></returns>
        IEnumerable<Child> GetAllChilds();
        /// <summary>
        /// This function return all the Childs of the mother. the checking is by the mother id
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        IEnumerable<Child> GetAllChildsByMother(Mother m);
        /// <summary>
        /// This function returns all the disabled childs
        /// </summary>
        IEnumerable<Child> GetSpecialChilds();
       
        IEnumerable<Nanny> GetAllMatchedNannies(Mother m, Child c, bool salary);
        /// <summary>
        /// this function return all the nannies that appropriate to the demands of the mother
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        IEnumerable<Nanny> GetAllNanniesByTerm(Mother m);
        /// <summary>
        /// This function return all the nannies
        /// </summary>
        /// <returns></returns>
        IEnumerable<Nanny> GetAllNannies();
        /// <summary>
        /// This function return the best 5 of the nannies
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        IEnumerable<Nanny> TheBestFive(Mother m);//get a term that the mother can conpromise on and return the best 5
        /// <summary>
        /// This function return all the nannies that working by the gov
        /// </summary>
        /// <returns></returns>
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
        void SetFullName(int id);
        IEnumerable<IGrouping<int, Nanny>> NanniesByContracts();
        IEnumerable<IGrouping<string, Contract>> GroupOfSortedContract();//sorted by the distances that i divided to types in sting



    }
}
