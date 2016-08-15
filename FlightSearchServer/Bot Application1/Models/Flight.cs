using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1.Models
{

    public class Flight
    {
        public int uid { get; set; }
        public string type { get; set; }
        public string flightNumber { get; set; }
        public string trafficTypeCode { get; set; }
        public string airlineCode { get; set; }
        public string destinationCode { get; set; }
        public string aircraftCode { get; set; }
        public string flightStatusCode { get; set; }
        public string originCode { get; set; }
        public string beltNumber { get; set; }
        public object gateNumber { get; set; }
        public string trafficTypeName { get; set; }
        public string terminal { get; set; }
        public string fullName { get; set; }
        public string fullNameA { get; set; }
        public Lang lang { get; set; }
        public int lastChanged { get; set; }
        public long scheduled { get; set; }
        public long estimated { get; set; }
        public long actual { get; set; }
    }

    public class Lang
    {
        public En en { get; set; }
        public Ae ae { get; set; }
    }

    public class En
    {
        public string airlineName { get; set; }
        public string originName { get; set; }
        public string destinationName { get; set; }
        public string flightStatusText { get; set; }
    }

    public class Ae
    {
        public string airlineName { get; set; }
        public string originName { get; set; }
        public string destinationName { get; set; }
        public string flightStatusText { get; set; }
    }

}


