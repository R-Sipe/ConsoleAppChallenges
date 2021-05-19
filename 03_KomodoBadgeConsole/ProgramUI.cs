using _03_KomodoBadgeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadgeConsole
{
    class ProgramUI
    {
        private BadgeRepository _repo = new BadgeRepository();
        public void Run()
        {
            SeedBadgeList();
            Menu();
        }
        private void Menu()
        {
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("Hello Security Admin, what would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges");
                string userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "1":
                    case "one":
                        AddABadge();
                        break;
                    case "2":
                    case "two":
                        EditABadge();
                        break;
                    case "3":
                    case "three":
                        ListAllBadges();
                        break;
                    default:
                        Console.WriteLine("Input not taken");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddABadge()
        {
            Console.Clear();
            Badge addNewBadge = new Badge();
            Console.WriteLine("What is the badge number:");
            string badgeAsString = Console.ReadLine();
            int badgeAsInt = Convert.ToInt32(badgeAsString);
            addNewBadge.BadgeID = badgeAsInt;
            Console.WriteLine("List a door that it needs access to:");
            //addNewBadge.DoorNames = Door(Console.ReadLine());
            List<Door> newAccess = new List<Door>();
            bool keepLooping = true;
            while (keepLooping)
            {
                string newDoorName = Console.ReadLine();
                Door newDoor = new Door(newDoorName);
                newAccess.Add(newDoor);
                Console.WriteLine("Do you want to add more doors?");
                string userChoice = Console.ReadLine();
                if (userChoice.ToLower() == "yes")
                {
                    Console.WriteLine("List of another door to access");
                    keepLooping = true;
                }
                else
                {
                    keepLooping = false;
                }
            }
            addNewBadge.DoorNames = newAccess;
            _repo.AddNewBadge(addNewBadge.BadgeID, addNewBadge.DoorNames);
        }

        private void EditABadge()
        {
            Console.Clear();
            Badge editBadge = new Badge();
            Console.WriteLine("What is the badge you want to edit?:");
            string badgeAsString = Console.ReadLine();
            int badgeAsInt = Convert.ToInt32(badgeAsString);
            editBadge.BadgeID = badgeAsInt;
            Dictionary<int, List<Door>> userBadge = _repo.ViewAllBadges();
            foreach (KeyValuePair<int, List<Door>> badge in userBadge)
            {
                if (badge.Key == editBadge.BadgeID)
                {
                    Console.WriteLine($"{badge.Key} has acces to doors");
                    foreach (Door door in badge.Value)
                    {
                        Console.WriteLine(door.DoorName);
                    }

                    Console.WriteLine("What would you like to do?\n" +
                        "1. Remove Door\n" +
                        "2. Add Door");
                    int userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput == 1)
                    {
                        Console.WriteLine("which door do you want to remove?");
                        string doorAsString = Console.ReadLine();
                        Door door = new Door(doorAsString);
                        _repo.RemoveDoorFromBadge(badgeAsInt, door);
                        Console.WriteLine("Door was removed");
                    }
                    if (userInput == 2)
                    {
                        Console.WriteLine("Which door do you want to add?");
                        string doorAsString = Console.ReadLine();
                        Door door = new Door(doorAsString);
                        _repo.AddDoorToBadge(badgeAsInt, door);
                        Console.WriteLine("Door was added");
                    }
                }
                Console.WriteLine("User input not recognized");
            }

        }

        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<Door>> allBadges = _repo.ViewAllBadges();
            foreach (KeyValuePair<int, List<Door>> badge in allBadges)
            {
                Console.WriteLine($"Badge #: {badge.Key}\n" +
                    $"Door Access:");
                foreach (Door door in badge.Value)
                {
                    Console.WriteLine(door.DoorName);
                }
            }
        }

        private void SeedBadgeList()
        {
            _repo.AddNewBadge(123, new List<Door> { new Door("A1")});
            Door lab = new Door("A2");
            Door office = new Door("A3");
            Door entrance = new Door("A4");
           
            _repo.AddDoorToBadge(123, lab);
            _repo.AddDoorToBadge(123, office);
            _repo.AddDoorToBadge(123, entrance);

        }
    }
}
