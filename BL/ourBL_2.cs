using BE;
using GoogleMapsApi;

using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BL
{
     public  partial class ourBL:IBL
    {
        #region nanny functions
        /// <summary>
        /// Get All The Nannies Who Match To Specific Mom By Checking Their Schedules And Destinations
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public IEnumerable<Nanny> GetAllNanniesByTerm(Mother m)
        {
            var v1 = dal.GetAllNannies(n => CheckSchedule(m, n)==true);
            var v2 = DestinationRealm(m);
            var result= from item1 in v1 from item2 in v2 where (item1 == item2) select item1;
            return result;
        }
          public IEnumerable<Nanny> DestinationRealm(Mother m)
        {

                return dal.GetAllNannies(n => (CalculateDistance(m.address, n.address) <= m.nannyArea*1000));
        
        }
         public IEnumerable<Nanny> WorkingByTheGov()
        {

            return dal.GetAllNannies(n =>n.HolidaysByTheGOV==true);
        }
         public IEnumerable<Nanny> GetAllNannies()
        {
            return dal.GetAllNannies();
        }
         public Nanny GetNanny(int id)
        {
            return dal.GetNanny(id);
        }
         public IEnumerable<Nanny> GetAllNanniesFromJerusalem()
        {
            return dal.GetAllNannies(m => m.address.Substring(0, 9) == "Jerusalem");
        }

        public IEnumerable<Nanny> GetAllMatchedNannies(Mother m,Child c, bool salary)//if the salary is T =salary per hour
        {
            var term1 = GetAllNanniesByTerm(m);
            var term2 = dal.GetAllNannies(n => n.SalaryPerHour == salary);
            var result1= from item1 in term1 from item2 in term2
                        where (item1.id == item2.id) select item1;

            long elapsedTicks = DateTime.Now.Ticks - c.birth.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            var result2 =
                result1.Where(nanny => (nanny.MinAge <= (elapsedSpan.TotalDays / 30) && nanny.MaxAge >= (elapsedSpan.TotalDays / 30)));
          
            return result2;
          
        }

        public IEnumerable<Nanny> TheBestFive(Mother m)//i assume that mother preffer to compromise on the distance of the address of the nanny and dont changing the schedule 
        {
            var v=    dal.GetAllNannies(n => CheckSchedule(m, n)==true);
            var result=v.OrderBy(i => CalculateDistance(i.address,m.address)).FirstOrDefault();
            if (result != null)
                return v.OrderBy(i => CalculateDistance(i.address, m.address)).Take(5);
            else
                return null;
        }
        #endregion 
        #region mother functions
        public IEnumerable<Mother> GetAllMothers()
        {
            return dal.GetAllMothers();
        }
        public Mother GetMother(int id)
        {
            return dal.GetMother(id);
        }

    public IEnumerable<Mother> GetAllMothersFromJerusalem()
        {
            return dal.GetAllMothers(m => m.address.Substring(0, 9) == "Jerusalem");
        }
        #endregion
        #region grouping functions
        public IEnumerable<IGrouping<int, Nanny>> GroupOfNannies(bool MinOrMax)//min is false.  max is true
        {
            var result= from item in dal.GetAllNannies()
                   orderby GetTypeOfAge(item.MinAge)
            group item by GetTypeOfAge(item.MinAge);
            if (MinOrMax == false)//minimum order
                return result;
            else//maximum order
                return result.Reverse();

        }
        public IEnumerable<IGrouping<string, Nanny>> NannyGroupByExperience()
        {
            var result = from item in dal.GetAllNannies()
                         orderby GetTypeOfExperience(item.experience)
                         group item by GetTypeOfExperienceString(GetTypeOfExperience(item.experience));


                return result;
      

        }

        private string GetTypeOfExperienceString(int exp)
        {
            if (exp == 1)
                return "amateur";
            if (exp == 2)
                return "Internship";
            if (exp == 3)
                return "Nanny as a Job";
            if (exp == 4)
                return "Professional Nanny";
       else
                return "Super Nanny!";

        }
   private int GetTypeOfExperience(int d)
        {

            if (d <= 3)
                return 1;
            if (d <= 5)
                return 2;
            if (d <= 8)
                return 3;
            if (d <= 15)
                return 4;
            else
                return 5;

        }
        public IEnumerable<IGrouping<string, Child>> ChildsGroupBySpecial()//min is false.  max is true
        {
            var result = from item in dal.GetAllChilds()
                         orderby (item.special)
                         group item by ((item.special) ? "Special Child" : "Simple Child");

            return result;


        }

        public IEnumerable<IGrouping<string, Contract>> GroupOfSortedContract()//the key that allow me to compare is the key thar returned from the GetDistanceType
        {
            return from item in dal.GetAllContracts()
                   group item by GetDistanceType(item.distance);
        }


        #endregion
        #region Child functions

        public Child GetChild(int id)
        {
            return dal.GetChild(id);
        }
private int GetTypeOfAge(int d)
        {

            if (d <= 3)
                return 1;
            if (d <= 5)
                return 2;
            if (d <= 8)
                return 3;
            if (d <= 12)
                return 4;
            if (d <= 18)
                return 5;

            if (d <= 24)
                return 6;
            else
                return 7;

        }
     


        public IEnumerable<Child> GetAllChilds()
        {
            return dal.GetAllChilds();
        }

        public  IEnumerable<Child> NeedNanny()
        {
            return dal.GetAllChilds( c=>c.nannyID==null);


        }

        public IEnumerable<Child> GetSpecialChilds()
        {
            return dal.GetAllChilds(c => c.special == true);
        }
        #endregion
        #region contract

          public Contract GetContract(int cont)
        {
            return dal.GetContract(cont);
        }

        public  bool CheckSchedule(Mother m,Nanny n)
        {
            for(int i=0;i<6;i++)
            {
                if(m.needNanny[i]==true)
                { 
                for (int j = 0; j < 2; j++)
                {
                    if (j==0 && 0 < n.schedule[j][ i].CompareTo(m.timeWork[j][ i]))//the starting time of the nanny should be earlier than of the mother
                        return false;
                    if (j == 1 && 0 > n.schedule[j][ i].CompareTo(m.timeWork[j][ i]))
                        return false;
                }
                }
            }
            return true;
        }
       
        public IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null)
        {
            return dal.GetAllContracts(predicat);
        }
        public int GetSumOfContracts(Func<Contract, bool> predicat = null)
        {
            var v= dal.GetAllContracts(predicat);
            int counter = 0;
            foreach(var item in v)
            {
                counter++;
            }
            return counter;
        }
     
        private string GetDistanceType(int d)
        {
           
            if (d <=500)
                return "Small Distance";
            if (d<= 1000)
                return "Not big Distance";
            if (d <= 20000)
                return "Plausible Distance";
            if (d <= 50000)
                return "Almost unacceptable Distance";
            else
                return "enormous distance";
        }

        public static int CalculateDistance(string source, string dest)
        {
            try
            {
                var drivingDirectionRequest = new DirectionsRequest()
                {
                    TravelMode = TravelMode.Walking,
                    Origin = source,
                    Destination = dest,
                };

                DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
                Route route = drivingDirections.Routes.First();
                Leg leg = route.Legs.First();
                return leg.Distance.Value;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return 0;
            }
            
        }

        public int GetNumOfContracts(object obj)
        {
            int id;
            int sum = 0;
          if(obj is Mother)
            {
                Mother temp = obj as Mother;
                id = temp.id;
                var v = GetAllContracts();
                foreach(var item in v)

                {
                    if (item.c.momId == id)
                        sum++;
                }
            }
            if (obj is Nanny)
            {
                Nanny temp = obj as Nanny;
                id = temp.id;
var v = GetAllContracts();
                foreach (var item in v)

                {
                    if (item.n.id == id)
                        sum++;
                }

            }
            return sum;
        }

        public void refresh()
        {
            
            dal = new DAL.Dal_XML_imp();//The ctor of the dal
        }
        #endregion
    }
  
}
