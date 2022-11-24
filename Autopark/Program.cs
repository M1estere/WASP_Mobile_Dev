namespace Second_Homework
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // Simple Car test
            Car car = new Car("Renault", 357, 1997);
            
            // Console.WriteLine(car.ToString());
            
            // Passenger Car Test
            PassengerCar passengerCar = new PassengerCar("Logan", 500, 2002, 25);
            
            passengerCar.PrintServiceBook();
            passengerCar.GetReplacementYear("Steering Wheel");
            passengerCar.AddReplacedPart("Steering wheel", 2005);
            passengerCar.AddReplacedPart("Steering wheel", 2005);
            passengerCar.AddReplacedPart("k", 2005);
            passengerCar.AddReplacedPart("l", 2007);
            passengerCar.GetReplacementYear("Steering wheel");
            passengerCar.PrintServiceBook();

            // Console.WriteLine(passengerCar.ToString());
            
            // Truck Test
            Truck truck = new Truck("Super", 1200, 2020, 1500, 
                new Truck.DriverName("John", "Wick"));
            
            truck.PrintCarriage();
            truck.AddCarriage("Wool", 300);
            truck.AddCarriage("Wool", 150);
            truck.AddCarriage("Wool", 300);
            truck.AddCarriage("Food", 900);
            truck.AddCarriage("Recycle", 500);
            truck.RemoveCarriage("Wool");
            truck.AddCarriage("Recycle", 500);
            truck.PrintCarriage();
            truck.ChangeDriver(new Truck.DriverName("Sherlock", "Holmes"));
            
            // Console.WriteLine(truck.ToString());

            AutoPark autoPark = new AutoPark("My garage", new List<Car>()
            {
                car,
                passengerCar,
                truck
            });
            
            autoPark.AddTransport(new Truck("Ultra", 554, 2015, 2000, new Truck.DriverName("Mike", "Tyson")));
            
            Console.WriteLine(autoPark.ToString());
        }
    }

    internal class Car
    {
        protected string _brand;
        protected int _capacity;
        protected int _creationYear;

        internal Car(string brand, int capacity, int creationYear)
        {
            _brand = brand;
            _capacity = capacity;
            _creationYear = creationYear;
        }

        public override string ToString()
        {
            return $"Car:\n\tCar's brand: {_brand};\n\tCapacity: {_capacity};\n\tCreation date: {_creationYear}";
        }
    }
    
    internal class PassengerCar : Car
    {
        private int _passengerCapacity;
        private Dictionary<string, int> _serviceBook = new Dictionary<string, int>();

        internal PassengerCar(string brand, int capacity, int creationYear, int passengerCapacity) : base(brand, capacity, creationYear)
        {
            _passengerCapacity = passengerCapacity;
        }

        internal void AddReplacedPart(string partName, int year)
        {
            foreach (KeyValuePair<string, int> pair in _serviceBook)
            {
                if (pair.Key.Equals(partName))
                {
                    Console.WriteLine($"! Attention (`{_brand}` passenger car): The note about replacing {partName} in {year} already exists");
                    return;
                }
            }
            
            _serviceBook.Add(partName, year);
            Console.WriteLine(
                $"To `{_brand}` passenger car added note about replacing {partName} in {year}");
        }

        internal void GetReplacementYear(string replacedPart)
        {
            int replacementYear = 0;
            bool found = false;
            foreach (KeyValuePair<string, int> pair in _serviceBook)
            {
                if (pair.Key.Equals(replacedPart))
                {
                    replacementYear = pair.Value;

                    found = true;
                }
            }
            
            if (found == true) Console.WriteLine($"Passenger car of brand: `{_brand}`\n\t{replacedPart} was replaced in {replacementYear}");
            else Console.WriteLine($"{replacedPart} have(-s) not yet been replaced in `{_brand}` passenger car");
        }

        internal void PrintServiceBook()
        {
            int counter = 1;
            Console.WriteLine($"Passenger car of brand: {_brand}:");
            foreach (KeyValuePair<string, int> pair in _serviceBook)
            {
                Console.WriteLine($"\t{counter}. {pair.Key} was replaced in {pair.Value}");
                counter++;
            }
            
            if (counter == 1) Console.WriteLine($"\t!No part have been replaced yet");
        }

        public override string ToString()
        {
            return $"Passenger car:\n\tCar's brand: {_brand};\n\tCapacity: {_capacity};\n\tCreation date: {_creationYear};\n\tPassenger capacity: {_passengerCapacity}";
        }
    }

    internal class Truck : Car
    {
        internal struct DriverName
        {
            internal string Name;
            internal string Surname;

            public DriverName(string name, string surname)
            {
                Name = name;
                Surname = surname;
            }
        }
        
        private int _maxCarryingCapacity;
        private DriverName _driverParams;
        private Dictionary<string, int> _currentCarry = new Dictionary<string, int>();

        internal Truck(string brand, int capacity, int creationYear, int maxCarryingCapacity, DriverName driverParams) : base(brand, capacity, creationYear)
        {
            _maxCarryingCapacity = maxCarryingCapacity;
            _driverParams = driverParams;
        }

        internal void ChangeDriver(DriverName newDriverParams)
        {
            _driverParams.Name = newDriverParams.Name;
            _driverParams.Surname = newDriverParams.Surname;
        }

        internal void AddCarriage(string name, int weight)
        {
            int wholeCapacity = 0;
            foreach (KeyValuePair<string, int> pair in _currentCarry)
            {
                if (pair.Key.Equals(name))
                {
                    Console.WriteLine($"! Attention (`{_brand}` truck): the transport is already carrying {name}");
                    return;
                }

                wholeCapacity += pair.Value;
            }
            
            // check if capacity can handle new item
            if (wholeCapacity + weight > _maxCarryingCapacity)
            {
                Console.WriteLine($"! Attention (`{_brand}` truck): maximum carrying capacity is not enough for {name}, {weight} lbs");
                return;
            }
            
            _currentCarry.Add(name, weight);
            Console.WriteLine($"To `{_brand}` truck added carriage: {name}, {weight} lbs");
        }

        internal void RemoveCarriage(string name)
        {
            foreach (KeyValuePair<string, int> pair in _currentCarry)
            {
                if (pair.Key.Equals(name))
                {
                    _currentCarry.Remove(name);
                    Console.WriteLine($"`{_brand}` truck stopped carrying {name}, with weight: {pair.Value} lbs");
                    return;
                }
            }
            
            Console.WriteLine($"`{_brand}` truck is not carrying {name}");
        }

        internal void PrintCarriage()
        {
            int counter = 1;
            Console.WriteLine($"Truck of brand: {_brand}:");
            foreach (KeyValuePair<string, int> pair in _currentCarry)
            {
                Console.WriteLine($"\t{counter}. {pair.Key} with weight: {pair.Value} lbs");
                counter++;
            }
            
            if (counter == 1) Console.WriteLine($"\t!Nothing is being carried now");
        }

        public override string ToString()
        {
            return $"Truck:\n\tCar's brand: {_brand};\n\tCapacity: {_capacity};\n\t" +
                   $"Creation date: {_creationYear};\n\tMaximum carrying capacity: {_maxCarryingCapacity};\n\tDriver params: {_driverParams.Surname} {_driverParams.Name}";
        }
    }

    internal class AutoPark
    {
        private string _name;
        private List<Car> _cars;

        internal AutoPark(string name, List<Car> cars)
        {
            _name = name;
            _cars = cars;
        }

        internal void AddTransport(Car transport)
        {
            _cars.Add(transport);
        }

        public override string ToString()
        {
            int counter = 1;
            string result = "\n";
            foreach (Car car in _cars)
            {
                result += $"--------{counter}--------:\n{car.ToString()}\n-------- --------\n";
                counter++;
            }

            return result;
        }
    }
}