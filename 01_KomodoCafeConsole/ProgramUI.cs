using _01_KomodoCafeChallengeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafeChallengeConsole
{
    public class ProgramUI
    {
        private KomodoCafeRepository _repo = new KomodoCafeRepository();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepOpen = true;
            while (keepOpen)
            {
                Console.WriteLine("Choose a menu option:\n" +
                    "1. Create New Menu Items\n" +
                    "2. View All Menu Items\n" +
                    "3. Update Menu Items\n" +
                    "4. Delete Menu Items\n" +
                    "5. View Menu Items By Name");

                string userInput = Console.ReadLine();

                switch (userInput.ToLower())
                {
                    case "1":
                    case "one":
                        CreateNewMenuItems();
                        break;
                    case "2":
                    case "two":
                        ViewAllMenuItems();
                        break;
                    case "3":
                    case "three":
                        UpdateMenuItems();
                        break;
                    case "4":
                    case "four":
                        DeleteMenuItems();
                        break;
                    case "5":
                    case "five":
                        ViewMenuByName();
                        break;
                    default:
                        Console.WriteLine("Input not recognized");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewMenuItems()
        {
            Console.Clear();
            KomodoCafe newMenuItem = new KomodoCafe();

            Console.WriteLine("What is the new menu item?");
            newMenuItem.MealName =  Console.ReadLine();
            Console.WriteLine("What is the description of this item?");
            newMenuItem.MealDescription = Console.ReadLine();
            Console.WriteLine("What is the price of this item?");
            newMenuItem.MealPrice = Convert.ToDouble(Console.ReadLine());
            //string mealPriceAsString = Console.ReadLine();
            //double mealPriceAsDoulbe = Convert.ToDouble(mealPriceAsString);
            //newMenuItem.MealPrice = mealPriceAsDoulbe;
            Console.WriteLine("What is the main ingredient of this new item?\n" +
                "1. Bun\n" +
                "2. Lettuce\n" +
                "3. Meat\n" +
                "4. Pickle\n" +
                "5. Tomato\n" +
                "6. Ketchup\n" +
                "7. Mayo");
            string ingredientAsString = Console.ReadLine();
            int ingredientAsInt = Convert.ToInt32(ingredientAsString);
            newMenuItem.IngredientList = (IngredientList)ingredientAsInt;
            bool wasAddedCorrectly = _repo.AddItemsToMenu(newMenuItem);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("The item was added correctly");
            }else
            {
                Console.WriteLine("Item was not added, try again");
            }
        }

        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<KomodoCafe> fullMenu = _repo.GetMenu();
            foreach(KomodoCafe menu in fullMenu)
            {
                Console.WriteLine($"Meal Number: {menu.MealNumber}\n" +
                    $"Meal Name: {menu.MealName}\n" +
                    $"Meal Description: {menu.MealDescription}\n" +
                    $"Meal Price: {menu.MealPrice}\n" +
                    $"Ingredient List: {menu.IngredientList}");
            }
        }

        private void UpdateMenuItems()
        {
            Console.Clear();
            Console.WriteLine("Enter the menu item you want to update");
            string oldItem = Console.ReadLine();
            KomodoCafe newItems = new KomodoCafe();
            Console.WriteLine("What is the menu number?");
            string menuNumberAsString = Console.ReadLine();
            int menuNumberAsInt = Convert.ToInt32(menuNumberAsString);
            newItems.MealNumber = menuNumberAsInt;

            Console.WriteLine("What is the new menu item name?");
            newItems.MealName = Console.ReadLine();

            Console.WriteLine("Enter the new description");
            newItems.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the new price");
            string menuPriceAsString = Console.ReadLine();
            double menuPriceAsDouble = Convert.ToDouble(menuPriceAsString);
            newItems.MealPrice = menuPriceAsDouble;

            Console.WriteLine("Enter the new ingredients\n" +
                "1. Bun\n" +
                "2. Lettuce\n" +
                "3. Meat\n" +
                "4. Pickle\n" +
                "5. Tomato\n" +
                "6. Ketchup\n" +
                "7. Mayo");
            string ingredientsAsString = Console.ReadLine();
            int ingredientsAsInt = Convert.ToInt32(ingredientsAsString);
            newItems.IngredientList = (IngredientList)ingredientsAsInt;
            _repo.DeleteExistingMenuItems(oldItem);
            _repo.AddItemsToMenu(newItems);
        }

        private void DeleteMenuItems()
        {
            Console.Clear();
            KomodoCafe deleteMenuItem = new KomodoCafe();
            Console.WriteLine("What item do you want to delete?");
            bool wasDeleted = _repo.DeleteExistingMenuItems(Console.ReadLine());
            if (wasDeleted)
            {
                Console.WriteLine("Items were deleted");
            }
            else
            {
                Console.WriteLine("Did not delete items");
            }

        }

        private void ViewMenuByName()
        {
            Console.Clear();
            Console.WriteLine("What menu item do you want to see?");
            KomodoCafe displayMenu = _repo.GetMenuByName(Console.ReadLine());
            if(displayMenu != null)
            {
                Console.WriteLine($"Meal Number: {displayMenu.MealNumber}\n" +
                    $"Meal Name: {displayMenu.MealName}\n" +
                    $"Meal Description: {displayMenu.MealDescription}\n" +
                    $"Meal Price: {displayMenu.MealPrice}\n" +
                    $"Ingredient List: {displayMenu.IngredientList}");
            }
            else
            {
                Console.WriteLine("There isnt a menu item by that name");
            }
        }
    }
}
