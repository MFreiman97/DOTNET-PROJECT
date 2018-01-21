using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL//
{
  public  interface Idal
    {       /// <summary>
            ///Adding nanny to the repository
            /// </summary>
            /// <param name="n"></param>
        void addNanny(Nanny n);
        /// <summary>
        /// delete nanny from the repository
        /// </summary>
        /// <param name="n"></param>
        void deleteNanny(Nanny n);
        /// <summary>
        /// update the details of a nanny .i assume that the comparapble paramater is the id.
        /// </summary>
        /// <param name="n"></param>
        void updateNanny(Nanny n);
        /// <summary>
        /// Get nanny from the repository by his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Nanny GetNanny(int id);
        /// <summary>
        /// Add mother to the repository
        /// </summary>
        /// <param name="m"></param>
        void addMom(Mother m);
        /// <summary>
        /// Delete mother from the repository
        /// </summary>
        /// <param name="m"></param>
        void deleteMom(Mother m);
        /// <summary>
        /// Update mother in the repository
        /// </summary>
        /// <param name="m"></param>
        void updateMom(Mother m);
        /// <summary>
        /// Get mother from the repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Mother GetMother(int id);

        /// <summary>
        /// Add Child to the repository
        /// </summary>
        /// <param name="c"></param>
        void addChild(Child c);
        /// <summary>
        /// Delete child from the repository
        /// </summary>
        /// <param name="c"></param>
        void deleteChild(Child c);
        /// <summary>
        /// Update child in the repository
        /// </summary>
        /// <param name="c"></param>
        void updateChild(Child c);//.i assume that the comparapble paramater is the id.
        /// <summary>
        /// Get child from the repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Child GetChild(int id);
        /// <summary>
        /// Add contract to the repository
        /// </summary>
        /// <param name="c"></param>
        void addContract(Contract c);
        /// <summary>
        /// Get contract from the repository
        /// </summary>
        /// <param name="cont"></param>
        /// <returns></returns>
        Contract GetContract(int cont);
        /// <summary>
        /// Delete contract from the repository
        /// </summary>
        /// <param name="c"></param>
        void deleteContract(Contract c);
        /// <summary>
        /// Update contract in the repository
        /// </summary>
        /// <param name="c"></param>
        void updateContract(Contract c);//.i assume that the comparapble paramater is the id.
        /// <summary>
        /// This function return all the nannies in the repository by some predicate
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        IEnumerable<Nanny> GetAllNannies(Func<Nanny, bool> predicat = null);
        /// <summary>
        /// This function return all the Mothers in the repository by some predicate
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        IEnumerable<Mother> GetAllMothers(Func<Mother, bool> predicat = null);
        /// <summary>
        /// This function return all the Contracts in the repository by some predicate
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null);
        /// <summary>
        /// This function return all the Childs in the repository by some predicate
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        IEnumerable<Child> GetAllChilds(Func<Child, bool> predicat = null);
     
    }
}
