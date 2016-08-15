using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using Bot_Application1.Models;
using FlightExperienceBot;
using Bot_Application1.Filters;
using WebApi.OutputCache.V2;

namespace Bot_Application1
{
    //  [BotAuthentication]
    [EnableCors(origins: "*", headers: "*", methods: "*")] 
    [RoutePrefix("")]
    [CacheWebApiAttribute(Duration=8000)]
    public class MessagesController : ApiController
    {

        
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                

                FlightLUIS stLuis = await LUISClient.ParseInput(message.Text);
                string strRet = string.Empty;
                string strStock = message.Text;
                //
    
                string departureCity = null;
                string arrivalCity = null;
                string dayOfWeek = null;
                string airline = null;

                if (stLuis.intents != null && stLuis.intents.Count() > 0)
                {


                    if (stLuis.entities.Length > 0)
                    {
                        foreach (var entity in stLuis.entities)
                        {
                            switch (entity.type)
                            {

                                case "DepartureCity":
                                    departureCity =entity.entity;
                                    break;
                                case "ArrivalCity":
                                    arrivalCity =entity.entity;
                                    break;
                                case "DayOfWeek":

                                    dayOfWeek = entity.entity;
                                 
                                    break;
                                case "Airline":
                                    airline = entity.entity;
                                    break;

                            }
                        }
                    }



                }

                string uri = GetUri(departureCity, arrivalCity);

                var repo = new FlightRepo(uri);
                var flights = await repo.GetFlight(departureCity,arrivalCity,dayOfWeek,airline);
                var json = JsonConvert.SerializeObject(flights);

                return message.CreateReplyMessage(json);
            }
            else
            {
                return HandleSystemMessage(message);
            }


        }

        private string GetUri(string departureCity, string arrivalCity)
        {
            string uri = null;
            if(departureCity!=null && (departureCity.ToLower() == "dubai" || departureCity.ToLower() == "dbx"))
            {
                uri= "http://dubaiairports.ae/api/flight/departures";
            }
            else if (arrivalCity != null && (arrivalCity.ToLower() == "dubai" || arrivalCity.ToLower() == "dbx"))
            {
                uri= "http://www.dubaiairports.ae/api/flight/arrivals";
            }
            else if (arrivalCity != null && (arrivalCity.ToLower() != "dubai" || arrivalCity.ToLower() != "dbx"))
            {
                uri = "http://dubaiairports.ae/api/flight/departures";
            }
            if (departureCity != null && (departureCity.ToLower() != "dubai" || departureCity.ToLower() != "dbx"))
            {
                uri = "http://dubaiairports.ae/api/flight/arrivals";
            }
            return uri;
        }


        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
                return message.CreateReplyMessage("Hello Botty ");
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}