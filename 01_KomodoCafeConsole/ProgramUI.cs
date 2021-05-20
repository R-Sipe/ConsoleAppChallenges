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
        private MenuItemRepository _repo = new MenuItemRepository();
        public void Run()
        {
            SeedMenuList();
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
            MenuItem newMenuItem = new MenuItem();
            var ingredientList = new List<string>();

            Console.WriteLine("What is the new menu item?");
            newMenuItem.MealName = Console.ReadLine();
            Console.WriteLine("What is the description of this item?");
            newMenuItem.MealDescription = Console.ReadLine();
            Console.WriteLine("What is the price of this item?");
            newMenuItem.MealPrice = Convert.ToDecimal(Console.ReadLine());
            //string mealPriceAsString = Console.ReadLine();
            //double mealPriceAsDoulbe = Convert.ToDouble(mealPriceAsString);
            //newMenuItem.MealPrice = mealPriceAsDoulbe;
            Console.WriteLine("Enter ingredients of the item?(Enter 'stop' to quit)\n" +
                "1. Bun\n" +
                "2. Lettuce\n" +
                "3. Meat\n" +
                "4. Pickle\n" +
                "5. Tomato\n" +
                "6. Ketchup\n" +
                "7. Mayo");
            string ingredient = Console.ReadLine();
            while (ingredient != "stop")
            {
                Console.Write("Ingredient Name: ");
                string input = Console.ReadLine();
                newMenuItem.IngredientList.Add(input);
            }
            _repo.AddItemsToMenu(newMenuItem);
        }

        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> fullMenu = _repo.GetAllMenuItems();
            foreach (MenuItem menu in fullMenu)
            {
                Console.Write($"Meal Number: {menu.MealNumber}\n" +
                    $"Meal Name: {menu.MealName}\n" +
                    $"Meal Description: {menu.MealDescription}\n" +
                    $"Meal Price: {menu.MealPrice}\n" +
                    $"Ingredients: ");

                foreach (string ingredient in menu.IngredientList)
                {
                    Console.Write($" {ingredient}");
                }
                Console.WriteLine();
            }
        }

        private void UpdateMenuItems()
        {
            Console.Clear();

            Console.WriteLine("Enter the number of the menu item you wish to update");
            int oldItem = Convert.ToInt32(Console.ReadLine());
            
            MenuItem mealToUpdate = _repo.GetMenuItemByNumber(oldItem);

            Console.Write("Add a new meal number: ");
            int menuNumber = Convert.ToInt32(Console.ReadLine());
            mealToUpdate.MealNumber = menuNumber;

            Console.WriteLine("What is the new menu item name?");
            mealToUpdate.MealName = Console.ReadLine();

            Console.WriteLine("Enter the new description");
            mealToUpdate.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the new price");
            string newPriceInput = Console.ReadLine();
            decimal newPrice = Convert.ToDecimal(newPriceInput);
            mealToUpdate.MealPrice = newPrice;

            List<string> listOfIngredients = new List<string>();
            Console.WriteLine("Enter a new list of ingredients: ");
            string newIngredientsInput = Console.ReadLine();

                while (newIngredientsInput != "stop")
                {
                    listOfIngredients.Add(newIngredientsInput);
                break;
                }
            
            _repo.UpdateExistingMenuItems(newIngredientsInput, mealToUpdate);


            mealToUpdate.IngredientList = listOfIngredients;


            Console.WriteLine($"Updated {oldItem} to:" +
                $"\n#: {mealToUpdate.MealNumber}" +
                $"\nName: {mealToUpdate.MealName}" +
                $"\nDescription: {mealToUpdate.MealDescription}" +
                $"\nPrice: {mealToUpdate.MealPrice}" +
                $"\nIngredients:");

            foreach (string ingredient in mealToUpdate.IngredientList)
            {
                Console.WriteLine($" {ingredient} ");
            }

            //Console.Write($"{mealToUpdate.MealPrice}");

        }

        private void DeleteMenuItems()
        {
            Console.Clear();
            MenuItem deleteMenuItem = new MenuItem();
            Console.WriteLine("What item (input name) do you want to delete?");
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
            MenuItem displayMenu = _repo.GetMenuByName(Console.ReadLine());
            if (displayMenu != null)
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

        private void SeedMenuList()
        {
            MenuItem itemOne = new MenuItem(1, "burgers", "juicy burgers nice", 3.15M, new List<string> { "bun, lettuce, tomato, cheese, ketchup" });
            MenuItem itemTwo = new MenuItem(2, "Tacos", "Shrimp Tacos with onions and garlic garnish", 5.15M, new List<string> { "Tortilla, cheese, onion, lettuce, garlic, shrimp" });
            MenuItem itemThree = new MenuItem(3, "Chicken Nuggies", "Chicken nuggies for the lil' eaters", 3.05M, new List<string> { "Chicken, fries, ketchup/honey mustard" });
            MenuItem itemFour = new MenuItem(4, " Ceaser Salad", "A block of lettuce with chicken and ceaser dressing", 6.25M, new List<string> { "lettuce, dressing(ceaser), croutons, chicken" });
            
            _repo.AddItemsToMenu(itemOne);
            _repo.AddItemsToMenu(itemTwo);
            _repo.AddItemsToMenu(itemThree);
            _repo.AddItemsToMenu(itemFour);
        }
    }
}
