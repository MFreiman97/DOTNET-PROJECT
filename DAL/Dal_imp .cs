using System;//MATANYA PART
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
        public static int Contnum = 0;
        public Dal_imp()
        {
           new DataSource();

        }
        public void addChild(Child c)
        {
            if (GetChild(c.id) != null)  
                DataSource.childs.Add(c);
            else
                throw new Exception("the Child you tried to add already exist!");

        }

        public void addContract(Contract c)
        {
            c.contnum = Contnum++;
            DataSource.contracts.Add(c);
    
            c.n.contracts++;
        }

        public void addMom(Mother m)
        {
            if (GetMother(m.id)!=null)
            {
             DataSource.mothers.Add(m);
            }
          else
                throw new Exception("the Mother you tried to add already exist!");
        }

        public void addNanny(Nanny n)
        {
            if(GetNanny(n.id) != null)
            {
                   DataSource.nannies.Add(n);
            }
          else
                throw new Exception("the Nanny you tried to add already exist!");
     
        }

        public void deleteChild(Child c)
        {
            if(GetChild(c.id)!=null)
            DataSource.childs.Remove(c);
            else
              throw new Exception("the Child you tried to delete wasnt exist!");
        }

        public void deleteContract(Contract c)
        {
            DataSource.contracts.Remove(c);
            c.n.contracts--;
        }

        public void deleteMom(Mother m)
        {
            if(GetMother(m.id) != null)
            {
              DataSource.mothers.Remove(m);
            }
          else
                throw new Exception("the Mother you tried to delete wasnt exist!");
           
        }

        public void deleteNanny(Nanny n)
        {
          
            if (GetNanny(n.id) != null)
            {
              DataSource.nannies.Remove(n);
            }
            else
                throw new Exception("the Nanny you tried to add wasnt exist!");

        }

        public IEnumerable<Child> GetAllChildsByMother(Mother m)
        {
            return DataSource.childs.Where(c => c.momId == m.id);
        }

        public IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.contracts.AsEnumerable();

            return DataSource.contracts.Where(predicat);
        }

        public IEnumerable<Mother> GetAllMothers(Func<Mother, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.mothers.AsEnumerable();

            return DataSource.mothers.Where(predicat);
        }

        public IEnumerable<Nanny> GetAllNannies(Func<Nanny, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.nannies.AsEnumerable();

            return DataSource.nannies.Where(predicat);
        }

        public Child GetChild(int id)
        {
            return DataSource.childs.Find(c => c.id == id);
        }

        public Mother GetMother(int id)
        {
            return DataSource.mothers.Find(m => m.id == id);
        }

        public Nanny GetNanny(int id)
        {
            return DataSource.nannies.Find(n => n.id == id);
        }

        public void updateChild(Child c)
        {
            int index = DataSource.childs.IndexOf(c);// i need to use the icomparable 
            if(index!=-1)
            {
                DataSource.childs[index] = c;
            }
       
        }

        public void updateContract(Contract c)
        {
            int index = DataSource.contracts.IndexOf(c);// i need to use the icomparable 
            if (index != -1)
            {
                DataSource.contracts[index] = c;
            }


        }

        public void updateMom(Mother m)
        {
            int index = DataSource.mothers.IndexOf(m);
            if (index != -1)
            {
                DataSource.mothers[index] = m;
            }
        }

        public void updateNanny(Nanny n)
        {
            int index = DataSource.nannies.IndexOf(n);
            if (index != -1)
            {
                DataSource.nannies[index] = n;
            }
        }
    }
}
