
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafeChallengeRepo
{
    public class MenuItemRepository
    {
        private readonly List<MenuItem> _cafeDirectory = new List<MenuItem>();

        public bool AddItemsToMenu(MenuItem newItems)
        {
            int startingCount = _cafeDirectory.Count;
            _cafeDirectory.Add(newItems);
            bool isAdded = (_cafeDirectory.Count > startingCount) ? true : false;
            return isAdded;
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _cafeDirectory;
        }

        public MenuItem GetMenuByName(string name)
        {
            foreach (MenuItem item in _cafeDirectory)
            {
                if (item.MealName.ToLower() == name.ToLower())
                {
                    return (MenuItem)item;
                }
            }
            return null;
        }

        public MenuItem GetMenuItemByNumber(int id)
        {
            foreach (MenuItem item in _cafeDirectory)
            {
                if (item.MealNumber == id)
                {
                    return item;
                }
            }
            return null;
        }

        public bool UpdateExistingMenuItems(string originalItem, MenuItem newMenuItems)
        {
            MenuItem oldMenuItems = GetMenuByName(originalItem);
            if (oldMenuItems != null)
            {
                oldMenuItems.MealNumber = newMenuItems.MealNumber;
                oldMenuItems.MealName = newMenuItems.MealName;
                oldMenuItems.MealDescription = newMenuItems.MealDescription;
                oldMenuItems.MealPrice = newMenuItems.MealPrice;
                oldMenuItems.IngredientList = newMenuItems.IngredientList;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteExistingMenuItems(string name)
        {
            MenuItem menuItemsToDelete = GetMenuByName(name);
            if(menuItemsToDelete == null)
            {
                return false;
            }
            else
            {
                _cafeDirectory.Remove(menuItemsToDelete);
                return true;
            }
        }
    }
}
