
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafeChallengeRepo
{
    public class KomodoCafeRepository
    {
        private readonly List<KomodoCafe> _cafeDirectory = new List<KomodoCafe>();

        public bool AddItemsToMenu(KomodoCafe newItems)
        {
            int startingCount = _cafeDirectory.Count;
            _cafeDirectory.Add(newItems);
            bool isAdded = (_cafeDirectory.Count > startingCount) ? true : false;
            return isAdded;
        }

        public List<KomodoCafe> GetMenu()
        {
            return _cafeDirectory;
        }

        public KomodoCafe GetMenuByName(string name)
        {
            foreach (KomodoCafe item in _cafeDirectory)
            {
                if (item.MealName.ToLower() == name.ToLower())
                {
                    return (KomodoCafe)item;
                }
            }
            return null;
        }

        public bool UpdateExistingMenuItems(string originalItem, KomodoCafe newMenuItems)
        {
            KomodoCafe oldMenuItems = GetMenuByName(originalItem);
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
            KomodoCafe menuItemsToDelete = GetMenuByName(name);
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
