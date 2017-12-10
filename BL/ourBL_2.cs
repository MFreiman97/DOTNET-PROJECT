using BE;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL//MATANYA FUNCTIONS
{
    public partial class ourBL:IBL
    {
      
        public bool CheckSchedule(Mother m,Nanny n)
        {
            for(int i=0;i<6;i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j==0 && m.timeWork[j, i] < n.schedule[j, i])
                        return false;
                    if (j == 1 && m.timeWork[j, i] > n.schedule[j, i])
                        return false;
                }
            }
            return true;
        }
        public IEnumerable<Child> NeedNanny()
        {
            return dal.GetAllChilds( c=>c.nannyID==null);


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
        public  int CalculateDistance(string source, string dest)
        {
            var drivingDirectionRequest = new DirectionsRequest
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
        #region nanny functions
        public IEnumerable<Nanny> GetAllNannies(Mother m)
        {
            var v1 = dal.GetAllNannies(n => CheckSchedule(m, n));
            var v2 = DestinationRealm(m);
            var result= from item1 in v1 from item2 in v2 where (item1 == item2) select item1;
            return result;
        }
          public IEnumerable<Nanny> DestinationRealm(Mother m)
        {

            return dal.GetAllNannies(n => (CalculateDistance(m.address, n.address) <= m.nannyArea));
        }
         public IEnumerable<Nanny> WorkingByTheGov()
        {

            return dal.GetAllNannies(n =>n.HolidaysByTheGOV==true);
        }
        public IEnumerable<Nanny> TheBestFive(Mother m)//i assume that mother preffer to compromise on the distance of the address of the nanny and dont changing the schedule 
        {
            var v=    dal.GetAllNannies(n => CheckSchedule(m, n));
            return v.OrderBy(i => CalculateDistance(i.address,m.address)).Take(5);
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

       
    }
}
