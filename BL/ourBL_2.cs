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

        public IEnumerable<Nanny> GetAllMatchedNannies(Mother m, bool salary)//if the salary is T =salary per hour
        {
            var term1 = GetAllNanniesByTerm(m);
            var term2 = dal.GetAllNannies(n => n.SalaryPerHour == salary);
            var result= from item1 in term1 from item2 in term2
                        where (item1 == item2) select item1;
            return result;
        }

        public IEnumerable<Nanny> TheBestFive(Mother m)//i assume that mother preffer to compromise on the distance of the address of the nanny and dont changing the schedule 
        {
            var v=    dal.GetAllNannies(n => CheckSchedule(m, n)==true);
            return v.OrderBy(i => CalculateDistance(i.address,m.address)).Take(5);//error
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
                    if (j==0 && 0 < n.schedule[j, i].CompareTo(m.timeWork[j, i]))//the starting time of the nanny should be earlier than of the mother
                        return false;
                    if (j == 1 && 0 > n.schedule[j, i].CompareTo(m.timeWork[j, i]))
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
           
            if (d <=5)
                return "Small Distance";
            if (d<= 10)
                return "Not big Distance";
            if (d <= 20)
                return "Plausible Distance";
            if (d <= 50)
                return "Almost unacceptable Distance";
            else
                return "enormous distance";
        }

        public static int CalculateDistance(string source, string dest)
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
        #endregion   
    }
  
}
