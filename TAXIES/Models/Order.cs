using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAXIES.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public int DriverID { get; set; }
        public int CarID { get; set; }
        public string DepPlace { get; set; }
        public string DestPlace { get; set; }
        public int Time { get; set; }
        public string Info { get; set; }

        public Client Client { get; set; }
        public Driver Driver { get; set; }
        public Car Car { get; set; }
    }
}
