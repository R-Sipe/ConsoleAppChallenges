using _02_KomodoClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsConsole
{
    public class ProgramUI
    {
        private ClaimRepository _repo = new ClaimRepository();
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Select a menu option\n" +
                    "1. See All Claims\n" +
                    "2. View Next Claim\n" +
                    "3. Add New Claim");
                string userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "1":
                    case "one":
                        SeeAllClaims();
                        break;
                    case "2":
                    case "two":
                        //ViewNextClaim();
                        break;
                    case "3":
                    case "three":
                        //AddNewClaim();
                        break;
                    default:
                        Console.WriteLine("User input not recognized");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> allClaims = _repo.GetAllClaims();
            foreach(Claim claim in allClaims)
            {

            }
        }
    }
}
