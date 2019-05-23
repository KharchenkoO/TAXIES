using TAXIES.Models;
using System;
using System.Linq;
using TAXIES.Data;

namespace TAXIES.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TaxiContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Drivers.Any())
            {
                var drivers = new Driver[]
                {
                     new Driver{DriverPassport=4865,DriverName="Alexander",DriverBirth=1972,DriverTel= 46785},
                     new Driver{DriverPassport=7945,DriverName="Alonso",DriverBirth=1968,DriverTel=49975},
                     new Driver{DriverPassport=2496,DriverName="Anand",DriverBirth=1993,DriverTel=78546},
                     new Driver{DriverPassport=3968,DriverName="Barzdukas",DriverBirth=1800,DriverTel=97856},
                     new Driver{DriverPassport=2034,DriverName="Li",DriverBirth=1988,DriverTel=24658},
                     new Driver{DriverPassport=7589,DriverName="Justice",DriverBirth=1978,DriverTel=32564},
                     new Driver{DriverPassport=2458,DriverName="Norman",DriverBirth=1967,DriverTel=24568},
                     new Driver{DriverPassport=1548,DriverName="Olivetto",DriverBirth=1986,DriverTel=79865}
                };
                foreach (Driver d in drivers)
                {
                    context.Drivers.Add(d);
                }
                context.SaveChanges();
            }

            if (!context.Cars.Any())
            {
                var cars = new Car[]
                {
                    new Car{CarNumber=48653,CarClass=Class.A,CarSize=Size.S},
                    new Car{CarNumber=64533,CarClass=Class.B,CarSize=Size.M}
                };
                foreach (Car c in cars)
                {
                    context.Cars.Add(c);
                }
                context.SaveChanges();
            }

            if (!context.Clients.Any())
            {
                var clients = new Client[]
                {
                    new Client{ClientTel=48653,ClientName="Alexander",ClientBirth=1972},
                    new Client{ClientTel=54344,ClientName="Wend",ClientBirth=1975},
                    new Client{ClientTel=23444,ClientName="Gor",ClientBirth=1977}
            };
                foreach (Client d in clients)
                {
                    context.Clients.Add(d);
                }
                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                var orders = new Order[]
                {
                    new Order{ClientID=1,DriverID=3,CarID=1,DepPlace="FJHD",DestPlace="TFHR",Time=12,Info="FGXB" },
                };
                foreach (Order o in orders)
                {
                    context.Orders.Add(o);
                }
                context.SaveChanges();
            }
        }
    }
}