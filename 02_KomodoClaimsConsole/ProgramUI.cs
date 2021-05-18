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
            SeedClaimList();
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
                        ViewNextClaim();
                        break;
                    case "3":
                    case "three":
                        AddNewClaim();
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
            foreach (Claim claim in allClaims)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim: {claim.DateOfClaim}\n" +
                    $"Is Valid: {claim.IsValid}");
            }
        }

        private void ViewNextClaim()
        {
            Claim nextClaim = _repo.GetNextClaim();
            Console.WriteLine($"Claim ID: {nextClaim.ClaimID}\n" +
                    $"Claim Type: {nextClaim.ClaimType}\n" +
                    $"Description: {nextClaim.Description}\n" +
                    $"Date of Incident: {nextClaim.DateOfIncident}\n" +
                    $"Date of Claim: {nextClaim.DateOfClaim}\n" +
                    $"Is Valid: {nextClaim.IsValid}");
            Console.WriteLine("Do you want to deal with this claim now?(y/n)");
            string input = (Console.ReadLine().ToLower());
            switch (input)
            {
                case "y":
                    _repo.RemoveNextClaim();
                    Console.WriteLine("Queue was removed");
                    break;
                case "n":
                    Console.WriteLine("Claim was added back into queue");
                    break;
            }
        }

        private void AddNewClaim()
        {
            Console.Clear();
            Claim newClaimAdded = new Claim();
            Console.WriteLine("Enter the claim ID");
            string claimIdAsString = Console.ReadLine();
            int claimIdAsInt = Convert.ToInt32(claimIdAsString);
            newClaimAdded.ClaimID = claimIdAsInt;
            Console.WriteLine("Enter the claim type (Car = 1 etc.)");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = Convert.ToInt32(claimTypeAsString);
            newClaimAdded.ClaimType = (ClaimType)claimTypeAsInt;
            Console.WriteLine("Enter a claim description");
            newClaimAdded.Description = Console.ReadLine();
            Console.WriteLine("Amount of Damage");
            newClaimAdded.ClaimAmount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Date of accident");
            newClaimAdded.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Date of Claim");
            newClaimAdded.DateOfClaim = DateTime.Parse(Console.ReadLine());
            newClaimAdded.IsValid = IsClaimValid(newClaimAdded.DateOfClaim, newClaimAdded.DateOfIncident); // passing in
            _repo.AddNextClaim(newClaimAdded);
        }



        //helper methods
        private bool IsClaimValid(DateTime dateOfClaim, DateTime dateOfIncident) // returns something
        {
            TimeSpan timeSpan = dateOfClaim - dateOfIncident;
            {
                if (timeSpan.TotalDays > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void SeedClaimList()
        {
            Claim a = new Claim(1, ClaimType.Car, "Car accident on 465", 400.00d, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            Claim b = new Claim(2, ClaimType.Home, "House fire in kitchen", 40000.00d, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            Claim c = new Claim(3, ClaimType.Theft, "Stolen pancakes", 4.00d,new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), false);

            _repo.AddNextClaim(a);
            _repo.AddNextClaim(b);
            _repo.AddNextClaim(c);
        }
    }
}
