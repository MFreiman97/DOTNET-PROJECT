
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
        /// This function return the best 5 of the nannies. I assumed that the best 5 return all the mothers without limitation on the nanny area
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        IEnumerable<Nanny> TheBestFive(Mother m,bool TypeOfSalary);
        /// <summary>
        /// This function return all the nannies that working by the gov
        /// </summary>
        /// <returns></returns>
        IEnumerable<Nanny> WorkingByTheGov();
        /// <summary>
        /// return all the mothers 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Mother> GetAllMothers();
        /// <summary>
        /// return all the mother from jerusalem
        /// </summary>
        /// <returns></returns>
        IEnumerable<Mother> GetAllMothersFromJerusalem();
        /// <summary>
        /// this function return all the nannies from jerusalem
        /// </summary>
        /// <returns></returns>
        IEnumerable<Nanny> GetAllNanniesFromJerusalem();
        /// <summary>
        /// This function return all the contracts by predicate
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null);
        /// <summary>
        /// This function return how many contracts is answered on a term
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        int GetSumOfContracts(Func<Contract, bool> predicat = null);
        /// <summary>
        /// This function return a grouping of nanny by experience
        /// </summary>
        /// <returns></returns>
         IEnumerable<IGrouping<string, Nanny>> NannyGroupByExperience();
        /// <summary>
        /// This function is dividing the childrens to groups of disabled and undisabled
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<string, Child>> ChildsGroupBySpecial();
        
        IEnumerable<IGrouping<int, Nanny>> GroupOfNannies(bool sorted);
        /// <summary>
        /// This function return how many contracts is belonged to nanny
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int GetNumOfContracts(object obj);
        /// <summary>
        /// Set full name of a child after updating of the family name of his mother
        /// </summary>
        /// <param name="id"></param>
        void SetFullName(int id);
        /// <summary>
        /// This function checks if the times of the contract is ok
        /// </summary>
        /// <param name="cont"></param>
        /// <returns></returns>
         bool TimesCheck(Contract cont);
        /// <summary>
        /// This function checks if the age of the child is ok
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        bool childAge(Child ch);
        /// <summary>
        /// This function checks if the nanny passed the maximum  of her contracts
        /// </summary>
        /// <param name="na"></param>
        /// <returns></returns>
        bool nannyContracts(Nanny na);
        /// <summary>
        /// This function is dividing the nannies By how many contracts the nanny has
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<int, Nanny>> NanniesByContracts();
        /// <summary>
        /// this function sort the contracts  by the distances that i divided to types in sting
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<string, Contract>> GroupOfSortedContract();//s



    }
}
