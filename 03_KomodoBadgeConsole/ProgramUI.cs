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
            //SeedBadgeList();
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
            Console.WriteLine("What is the badge numnber?");
            string badgeAsString = Console.ReadLine();
            int badgeAsInt = Convert.ToInt32(badgeAsString);
            addNewBadge.BadgeID = badgeAsInt;
        }

        private void EditABadge()
        {

        }

        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<Door>> allBadges = _repo.ViewAllBadges();
            foreach( badge in allBadges)
        }
    }
}
