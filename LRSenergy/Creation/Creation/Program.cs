using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory factory = new CarFactory();
            var car = factory.Create("audi");
            Console.WriteLine(car.Model);

            ReflectionCarFactory reflectionCarFactory = new ReflectionCarFactory();
            var car2 = reflectionCarFactory.Create("ford");
            Console.WriteLine(car2.Model);

            Liner qe2 = new Liner {Name = "QE2"};
            Liner newQe2 = (Liner) qe2.New();

            Console.WriteLine(newQe2.Name);
        }
    }

    public abstract class VehicleFactory
    {
        public abstract Vehicle Create(string type);
    }

    public class CarFactory : VehicleFactory
    {
        public override Vehicle Create(string type)
        {
            Car car = null;
            switch (type.ToLower())
            {
                case "kia":
                    car = new Kia();
                    break;
                case "audi":
                    car  = new Audi();
                    break;
            }
            return car;
        }
    }

    public abstract class Car : Vehicle
    {
    }

    public class Kia : Car
    {
        public override string Model
        {
            get { return "Cee'd"; }
        }
    }

    public class Audi : Car
    {
        public override string Model
        {
            get { return "A6"; }
        }
    }

    public abstract class Vehicle
    {
        public abstract string Model { get; }
    }

    [Car(Type="ford")]
    public class Ford : Car
    {
        public override string Model
        {
            get { return "Mondeo"; }
        }
    }

    public class CarAttribute : Attribute
    {
        public string Type { get; set; }
    }

    public class ReflectionCarFactory : CarFactory
    {
        private readonly Dictionary<string, Type> Cars;
        public ReflectionCarFactory()
        {
            Cars =
            (from type in this.GetType().Assembly.GetTypes()
             let CarAttrs = type
                 .GetCustomAttributes(typeof(CarAttribute), false)
                 .OfType<CarAttribute>()
             where CarAttrs.Count() > 0
             select new { Type = type, Kind = CarAttrs.First().Type }
            ).ToDictionary(e => e.Kind, e => e.Type);
        }

        public override Vehicle Create(string type)
        {
            return (Car)Activator.CreateInstance(Cars[type.ToLower()]);
        }
    }

    public interface IBoatPrototype
    {
        Boat New();
    }

    public class Boat
    {
    }

    public class Liner : Boat, IBoatPrototype
    {
        public string Name { get; set; }
        public Boat New()
        {
            return new Liner {Name = Name};
        }
    }
}
