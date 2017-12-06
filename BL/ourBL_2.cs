using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL//MATANYA FUNCTIONS
{
    public partial class ourBL:IBL
    {
        public IEnumerable<Nanny> GetAllNannies(Mother m)
        {
            if (predicat == null)
                return DataSource.nannies.AsEnumerable();

            return DataSource.nannies.Where(predicat);
        }
        public IEnumerable<Nanny> TermsFunc(Mother m)
        {
            return from item in D.GetAllStudentCourse()
                   where item.StudentId == StudentId

}

        public IEnumerable<Child> NeedNanny()
        {
            return DAL.Idal.NeedNanny();


        }

    }
}
