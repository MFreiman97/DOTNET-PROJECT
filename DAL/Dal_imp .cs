using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using System.Collections;

namespace DAL
{
    internal  class Dal_imp : Idal
    {
        public Dal_imp()
        {
          //  new DataSource();

        }
        public  void addChild(Child c)
        {
            // i didnt check if the student is already exist!!
            DataSource.childs.Add(c);
            
        }

        public void addContract(Contract c)
        {
            DataSource.contracts.Add(c);
        }

        public void addMom(Mother m)
        {
            DataSource.mothers.Add(m);
        }

        public void addNanny(Nanny n)
        {
            DataSource.nannies.Add(n);
        }

        public void deleteChild(Child c)
        {
            DataSource.childs.Remove(c);
        }

        public void deleteContract(Contract c)
        {
            DataSource.contracts.Remove(c);
        }

        public void deleteMom(Mother m)
        {
            DataSource.mothers.Remove(m);
        }

        public void deleteNanny(Nanny n)
        {
            DataSource.nannies.Remove(n);
        }

        public void updateChild(Child c)
        {
            DataSource.childs = DataSource.childs.FindAll(ch => ch.id == c.id).ConvertAll(ch => ch = c);
        }

        public void updateContract(Contract c)
        {
            throw new NotImplementedException();
        }

        public void updateMom(Mother m)
        {
            throw new NotImplementedException();
        }

        public void updateNanny(Nanny n)
        {
            throw new NotImplementedException();
        }
    }
}
