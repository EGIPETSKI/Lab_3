using System;
using System.Collections.Generic;

namespace AirportAutomationSystem
{
    public class Passenger
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TicketNumber { get; set; }
        public bool IsRegistered { get; set; }

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
            Console.WriteLine($"Пассажир {FirstName} {LastName} зарегистрирован.");
        }
    }

    public class Flight
    {
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public string Status { get; set; }

        public Flight(string flightNumber, DateTime departureTime, string destination, string status = "Scheduled")
        {
            FlightNumber = flightNumber;
            DepartureTime = departureTime;
            Destination = destination;
            Status = status;
        }

        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Статус рейса {FlightNumber} обновлен на {Status}.");
        }
    }

    public class Aircraft
    {
        public string AircraftId { get; set; }
        public string Model { get; set; }
        public string Condition { get; set; }

        public Aircraft(string aircraftId, string model, string condition = "Operational")
        {
            AircraftId = aircraftId;
            Model = model;
            Condition = condition;
        }

        public void Service()
        {
            Condition = "Serviced";
            Console.WriteLine($"Самолет {AircraftId} обслужен.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string correctPassword = "123456";
            string enteredPassword;

            Console.WriteLine("Введите пароль:");
            enteredPassword = Console.ReadLine();

            if (enteredPassword != correctPassword)
            {
                Console.WriteLine("Неверный пароль. Доступ запрещен.");
                return;
            }

            List<Passenger> passengers = new List<Passenger>();
            List<Flight> flights = new List<Flight>();
            List<Aircraft> aircrafts = new List<Aircraft>();

            Console.WriteLine("Добро пожаловать в систему аэропорта!");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Регистрация пассажира");
                Console.WriteLine("2. Управление рейсами");
                Console.WriteLine("3. Обработка багажа");
                Console.WriteLine("4. Техническое обслуживание самолета");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите опцию: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("\nВведите имя пассажира:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Введите фамилию пассажира:");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Введите номер билета:");
                        string ticketNumber = Console.ReadLine();

                        Passenger newPassenger = new Passenger(firstName, lastName, ticketNumber);
                        passengers.Add(newPassenger);
                        newPassenger.Register();
                        break;

                    case "2":
                        Console.WriteLine("\nВведите номер рейса:");
                        string flightNumber = Console.ReadLine();
                        Console.WriteLine("Введите дату и время вылета (например, 2024-12-20 15:30):");
                        DateTime departureTime = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Введите пункт назначения:");
                        string destination = Console.ReadLine();

                        Flight newFlight = new Flight(flightNumber, departureTime, destination);
                        flights.Add(newFlight);
                        Console.WriteLine($"Рейс {flightNumber} добавлен.");
                        break;

                    case "3":
                        Console.WriteLine("\nВведите номер багажа:");
                        string baggageId = Console.ReadLine();
                        Console.WriteLine("Введите номер билета пассажира, к которому привязан багаж:");
                        string passengerTicket = Console.ReadLine();

                        Console.WriteLine($"Багаж {baggageId} отслежен для пассажира с билетом {passengerTicket}.");
                        break;

                    case "4":
                        Console.WriteLine("\nВведите ID самолета:");
                        string aircraftId = Console.ReadLine();
                        Console.WriteLine("Введите модель самолета:");
                        string aircraftModel = Console.ReadLine();
                        ///Вау новая строчка
                        Aircraft newAircraft = new Aircraft(aircraftId, aircraftModel);
                        aircrafts.Add(newAircraft);
                        newAircraft.Service();
                        break;

                    case "5":
                        exit = true;
                        Console.WriteLine("Выход из программы.");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}
