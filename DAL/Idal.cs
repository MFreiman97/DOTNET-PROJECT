﻿using BE;//MATANYA PART
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL//
{
  public  interface Idal
    {       /// <summary>
            /// Nanny's Functions
            /// </summary>
            /// <param name="n"></param>
        void addNanny(Nanny n);
        void deleteNanny(Nanny n);
        void updateNanny(Nanny n);//update the details of a nanny .i assume that the comparapble paramater is the id.
        Nanny GetNanny(int id);
        /// <summary>
        /// Mom's Functions
        /// </summary>
        /// <param name="m"></param>
        void addMom(Mother m);
        void deleteMom(Mother m);
        void updateMom(Mother m);//i assume that the comparapble paramater is the id.
        Mother GetMother(int id);

        /// <summary>
        /// Child's Functions
        /// </summary>
        /// <param name="c"></param>
        void addChild(Child c);
        void deleteChild(Child c);
        void updateChild(Child c);//.i assume that the comparapble paramater is the id.
        Child GetChild(int id);
        /// <summary>
        /// Contract's Functions
        /// </summary>
        /// <param name="c"></param>
        void addContract(Contract c);
        Contract GetContract(int cont);
        void deleteContract(Contract c);
        void updateContract(Contract c);//.i assume that the comparapble paramater is the id.
        IEnumerable<Nanny> GetAllNannies(Func<Nanny, bool> predicat = null);
        IEnumerable<Mother> GetAllMothers(Func<Mother, bool> predicat = null);
        IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null);
        IEnumerable<Child> GetAllChildsByMother(Mother m);
        IEnumerable<Child> GetAllChilds(Func<Child, bool> predicat = null);
     
    }
}
