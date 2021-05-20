using _04_KomodoOutingRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KomodoOutingsConsole
{
    public class ProgramUI
    {
        private OutingsRepository _repo = new OutingsRepository();
        public void Run()
        {
            //SeedOutingList();
            Menu();
        }
        private void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Select a menu item to continue\n" +
                    "1. Display All Outings\n" +
                    "2. Add Individual Outings\n" +
                    "3. Display individual outings cost by type");
                string userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "1":
                    case "one":
                        DisplayAllOutings();
                        break;
                    case "2":
                    case "two":
                        AddOutings();
                        break;
                    case "3":
                    case "three":
                        //DisplayOutingsByType();
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayAllOutings()
        {
            Console.Clear();
            List<Outings> allOutings = _repo.GetAllOutings();
            foreach (Outings outings in allOutings)
            {
                Console.WriteLine($"Attendance: {outings.Attendance}\n" +
                    $"Event Type: {outings.EventType}\n" +
                    $"Date Of Events: {outings.Date}\n" +
                    $"Cost Per Person: {outings.CostPerPerson}\n" +
                    $"Cost Per Event: {outings.CostPerEvent}");
            }
        }
        
        private void AddOutings()
        {
            Console.Clear();
            Outings addNewOutings = new Outings();
            Console.WriteLine("What is the event type? Golf = 1, bowling 2, amusment park 3, concert 4");
            string eventAsString = Console.ReadLine();
            int eventAsInt = Convert.ToInt32(eventAsString);
            addNewOutings.EventType = (EventType)eventAsInt;
            Console.WriteLine("What is the number of attendance");
            string attendanceAsString = Console.ReadLine();
            int attendanceAsInt = Convert.ToInt32(attendanceAsString);
            addNewOutings.Attendance = attendanceAsInt;
            Console.WriteLine("Date of Outing");
            string dateAsString = Console.ReadLine();
            int dateAsInt = Convert.ToInt32(dateAsString);
            addNewOutings.Date = new DateTime(dateAsInt);
            Console.WriteLine("Cost Per Person");
            string costPersonAsString = Console.ReadLine();
            double costPersonAsDoule = Convert.ToDouble(costPersonAsString);
            addNewOutings.CostPerPerson = costPersonAsDoule;
            Console.WriteLine("Cost Per Event");
            string costPerEventAsString = Console.ReadLine();
            double costPerEventAsDouble = Convert.ToDouble(costPerEventAsString);
            addNewOutings.CostPerEvent = costPerEventAsDouble;
        }
    }
}
