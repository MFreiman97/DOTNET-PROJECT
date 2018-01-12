using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum FLOORS { zero = 0, First, Second, Third, Fourth, Fifth, Sixth, Seventh };//i assume that the maximum floor is 7
    public enum ContractType { hourly, monthly };
    public enum ObjectOptions {Childs,Nannies,Mothers};
}
