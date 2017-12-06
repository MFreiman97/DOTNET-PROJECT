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
        //public IEnumerable<Nanny> GetAllNannies(Mother m)
        //{

        //    return dal.GetAllNannies(n => m.timeWork[0, 0] >= n.schedule[0, 0]);
        //}
        // public bool TermsFunc(Mother m)
        //{


        //}
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
        public IEnumerable<Nanny> DestinationRealm(Mother m)
        {

            return dal.GetAllNannies(n => (CalculateDistance(m.address, n.address) <= m.nannyArea));
        }
        public IEnumerable<Nanny> WorkingByTheGov()
        {

            return dal.GetAllNannies(n =>n.HolidaysByTheGOV==true);
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


    }
}
