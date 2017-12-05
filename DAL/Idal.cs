using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface Idal
    {       /// <summary>
            /// Nanny's Functions
            /// </summary>
            /// <param name="n"></param>
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
        void addContract(Contract c);
        void deleteContract(Contract c);
        void updateContract(Contract c);//.i assume that the comparapble paramater is the id.
    }
}
