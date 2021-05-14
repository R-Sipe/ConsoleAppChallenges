using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafeChallengeRepo
{
    public class KomodoCafe
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public double MealPrice { get; set; }


        public KomodoCafe() { }

        public KomodoCafe(int mealNumber, string mealName, string mealDescription, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
        }
    }
}
