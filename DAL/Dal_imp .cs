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
    public  class Dal_imp : Idal
    {
        public static int Contnum = 1;
        public Dal_imp()
        {
           new DataSource();

        }
        #region add and delete functions
        public void addChild(Child c)
        {
            if (GetChild(c.id) == null)  
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
            if (GetMother(m.id) == null)
            {
             DataSource.mothers.Add(m);
            }
          else
                throw new Exception("the Mother you tried to add already exist!");
        }

        public void addNanny(Nanny n)
        {
            if(GetNanny(n.id) == null)
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

        #endregion
        #region "get all" functions
        public IEnumerable<Child> GetAllChilds(Func<Child, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.childs.AsEnumerable();

            return DataSource.childs.Where(predicat);
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
        #endregion
        #region get by id functions
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
        public Contract GetContract(int co)
        {
            return DataSource.contracts.Find(n => n.contnum == co);
        }
        #endregion
        #region update functions
        /// <summary>
        /// The Function get a Child to update,looking for the id of all the childs and update by overriding
        /// </summary>
        /// <param name="c"></param>
        public void updateChild(Child c)
        {
            int index = DataSource.childs.FindIndex(x=>x.id==c.id);// i need to use the icomparable 
            if(index!=-1)
            {
                DataSource.childs[index] = c;
            }
       
        }
        /// <summary>
        /// The Function get a contract to update,looking for the contnum of all the contracts and update by overriding
        /// </summary>
        /// <param name="c"></param>
        public void updateContract(Contract c)
        {
            int index = DataSource.contracts.FindIndex(x=>x.contnum==c.contnum);// i need to use the icomparable 
            if (index != -1)
            {
                DataSource.contracts[index] = c;
            }


        }
        /// <summary>
        /// The Function get a Mother to update,looking for the id of all the Mothers and update by overriding
        /// </summary>
        /// <param name="c"></param>
        public void updateMom(Mother m)
        {
        

            int index = DataSource.mothers.FindIndex(x=>x.id==m.id);
            if (index != -1)
            {
                DataSource.mothers[index] = m;
            }

        }
        /// <summary>
        /// The Function get a Nanny to update,looking for the id of all the nannies and update by overriding
        /// </summary>
        /// <param name="c"></param>
        public void updateNanny(Nanny n)
        {
            int index = DataSource.nannies.FindIndex(x=>x.id==n.id);
            if (index != -1)
            {
                DataSource.nannies[index] = n;
            }
        }
        #endregion
    }
}
