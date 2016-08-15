using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Bot_Application1.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using Bot_Application1;

namespace FlightExperienceBot
{
    public class FlightRepo
    {
        private string uri;
      
        public FlightRepo()
        {
          
        }

        public FlightRepo(string uri)
        {
            this.uri = uri;
        }
        public async Task<List<Flight>> GetFlight(string departureCity, string arrivalCity,string dayOfWeek,string airline)
        {
 
            FlightSearch flightSearch = new FlightSearch();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            List<Flight> flights = new List<Flight>();

            if (response.IsSuccessStatusCode)
            {

              var dataObjects =await response.Content.ReadAsStringAsync();
                flightSearch = JsonConvert.DeserializeObject<FlightSearch>(dataObjects);
                flights= FilterFlights(flightSearch.flights, departureCity, arrivalCity, dayOfWeek, airline);
            }
           
            return flights;

        }

        private List<Flight>FilterFlights(List<Flight> flights,string departureCity,string arrivalCity,string dayOfWeek, string airline)
        {
        
            if(departureCity!=null)
            {
                flights = flights.Where(x => x.lang!=null && x.lang.en!=null && x.lang.en.originName!=null && x.lang.en.originName.ToLower() == departureCity.ToLower()).ToList();
            }

            if(arrivalCity!=null)
            {
                flights = flights.Where(x => x.lang!=null && x.lang.en!=null && x.lang.en.destinationName!=null &&  x.lang.en.destinationName.ToLower() == arrivalCity.ToLower()).ToList();
            }

            if (airline != null)
            {
                flights = flights.Where(x => x.fullName!=null && x.fullName.ToLower() == airline.ToLower()).ToList();
            }

            if(dayOfWeek !=null)
            {

                if(dayOfWeek.ToLower()=="weekend")
                {
                    flights = flights.Where(
                        x => DateHelpers.GetDayOfWeekString(DateHelpers.GetDate(x.scheduled)).ToLower() =="friday" ||
                        DateHelpers.GetDayOfWeekString(DateHelpers.GetDate(x.scheduled)).ToLower() == "saturday").ToList();

                }
                else
                {
                    flights = flights.Where(x => DateHelpers.GetDayOfWeekString(DateHelpers.GetDate(x.scheduled)).ToLower() == dayOfWeek.ToLower()).ToList();
                }
            }

            return flights;

        }
    }
}

