using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafeChallengeRepo
{
    public enum IngredientList { Bun = 1, Lettuce, Meat, Pickle, Tomato, Ketchup, Mayo}
    public class KomodoCafe
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public double MealPrice { get; set; }
        public IngredientList IngredientList { get; set; }


        public KomodoCafe() { }

        public KomodoCafe(int mealNumber, string mealName, string mealDescription, double mealPrice, IngredientList ingredientList)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
            IngredientList = ingredientList;
        }
    }
}
