using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAXIES.Models
{
    public enum Class
    {
        A, B, C, D, E
    }
    public enum Size
    {
        S, M, L, XL
    }
    public class Car
    {
        public int CarID { get; set; }
        public int CarNumber { get; set; }
        public Class CarClass { get; set; }
        public Size CarSize { get; set; }

        public ICollection<Order> Orders { get; set; }
    }


}
