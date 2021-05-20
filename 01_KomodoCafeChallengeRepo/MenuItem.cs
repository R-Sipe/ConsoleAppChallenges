using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafeChallengeRepo
{
    
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public decimal MealPrice { get; set; }
        public List<string> IngredientList { get; set; }


        public MenuItem() { }

        public MenuItem(int mealNumber, string mealName, string mealDescription, decimal mealPrice, List<string> ingredientList)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
            IngredientList = ingredientList;
        }

       
    }
}
