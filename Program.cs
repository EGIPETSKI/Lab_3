using System;
using System.Collections.Generic;

namespace AirportAutomationSystem
{
    public class Passenger
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string TicketNumber { get; private set; }
        public bool IsRegistered { get; private set; }

        public Passenger(string firstName, string lastName, string ticketNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            TicketNumber = ticketNumber;
            IsRegistered = false;
        }

        public void Register()
        {
            IsRegistered = true;
            NotifyRegistration();
        }

        private void NotifyRegistration()
        {
            Console.WriteLine($"Пассажир {FirstName} {LastName} зарегистрирован.");
        }
    }

    public class Flight
    {
        public string FlightNumber { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public string Destination { get; private set; }
        public string Status { get; private set; }

        public Flight(string flightNumber, DateTime departureTime, string destination, string status = "Scheduled")
        {
            FlightNumber = flightNumber;
            DepartureTime = departureTime;
            Destination = destination;
            Status = status;
        }

        public void UpdateStatus(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus)) throw new ArgumentException("Статус не может быть пустым.");

            Status = newStatus;
            Console.WriteLine($"Статус рейса {FlightNumber} обновлен на {Status}.");
        }
    }

    public class Aircraft
    {
        public string AircraftId { get; private set; }
        public string Model { get; private set; }
        public string Condition { get; private set; }

        public Aircraft(string aircraftId, string model, string condition = "Operational")
        {
            AircraftId = aircraftId;
            Model = model;
            Condition = condition;
        }

        public void Service()
        {
            Condition = "Serviced";
            NotifyServicing();
        }

        private void NotifyServicing()
        {
            Console.WriteLine($"Самолет {AircraftId} обслужен.");
        }
    }

    public static class Authentication
    {
        private const string CorrectPassword = "123456";

        public static bool Authenticate()
        {
            Console.WriteLine("Введите пароль:");
            string enteredPassword = Console.ReadLine();

            bool isAuthenticated = enteredPassword == CorrectPassword;
            if (!isAuthenticated)
            {
                Console.WriteLine("Неверный пароль. Доступ запрещен.");
            }

            return isAuthenticated;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (!Authentication.Authenticate()) return;

            List<Passenger> passengers = new();
            List<Flight> flights = new();
            List<Aircraft> aircrafts = new();

            Console.WriteLine("Добро пожаловать в систему аэропорта!");

            while (true)
            {
                DisplayMenu();
                string option = Console.ReadLine();

                if (!ProcessOption(option, passengers, flights, aircrafts)) break;
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Регистрация пассажира");
            Console.WriteLine("2. Управление рейсами");
            Console.WriteLine("3. Обработка багажа");
            Console.WriteLine("4. Техническое обслуживание самолета");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите опцию: ");
        }

        private static bool ProcessOption(string option, List<Passenger> passengers, List<Flight> flights, List<Aircraft> aircrafts)
        {
            switch (option)
            {
                case "1":
                    RegisterPassenger(passengers);
                    break;

                case "2":
                    AddFlight(flights);
                    break;

                case "3":
                    TrackBaggage();
                    break;

                case "4":
                    ServiceAircraft(aircrafts);
                    break;

                case "5":
                    Console.WriteLine("Выход из программы.");
                    return false;

                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }
            return true;
        }

        private static void RegisterPassenger(List<Passenger> passengers)
        {
            Console.WriteLine("\nВведите имя пассажира:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию пассажира:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введите номер билета:");
            string ticketNumber = Console.ReadLine();

            Passenger newPassenger = new Passenger(firstName, lastName, ticketNumber);
            passengers.Add(newPassenger);
            newPassenger.Register();
        }

        private static void AddFlight(List<Flight> flights)
        {
            Console.WriteLine("\nВведите номер рейса:");
            string flightNumber = Console.ReadLine();
            Console.WriteLine("Введите дату и время вылета (например, 2024-12-20 15:30):");
            DateTime departureTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите пункт назначения:");
            string destination = Console.ReadLine();

            Flight newFlight = new Flight(flightNumber, departureTime, destination);
            flights.Add(newFlight);
            Console.WriteLine($"Рейс {flightNumber} добавлен.");
        }

        private static void TrackBaggage()
        {
            Console.WriteLine("\nВведите номер багажа:");
            string baggageId = Console.ReadLine();
            Console.WriteLine("Введите номер билета пассажира, к которому привязан багаж:");
            string passengerTicket = Console.ReadLine();

            Console.WriteLine($"Багаж {baggageId} отслежен для пассажира с билетом {passengerTicket}.");
        }

        private static void ServiceAircraft(List<Aircraft> aircrafts)
        {
            Console.WriteLine("\nВведите ID самолета:");
            string aircraftId = Console.ReadLine();
            Console.WriteLine("Введите модель самолета:");
            string aircraftModel = Console.ReadLine();

            Aircraft newAircraft = new Aircraft(aircraftId, aircraftModel);
            aircrafts.Add(newAircraft);
            newAircraft.Service();
        }
    }
}
