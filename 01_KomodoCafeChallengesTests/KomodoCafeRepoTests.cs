using _01_KomodoCafeChallengeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafeChallengesTests
{
    [TestClass]
    public class KomodoCafeRepoTests
    {
        [TestMethod]
        public void AddToMenu_ShouldGetCorrectBoolean()
        {
            KomodoCafe cafe = new KomodoCafe();
            KomodoCafeRepository repository = new KomodoCafeRepository();
            bool addResult = repository.AddItemsToMenu(cafe);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenu_ShouldReturnCorrectCollection()
        {
            KomodoCafe cafe = new KomodoCafe();
            KomodoCafeRepository repository = new KomodoCafeRepository();
            repository.AddItemsToMenu(cafe);
            List<KomodoCafe> menu = repository.GetMenu();
            bool menuHasItems = menu.Contains(cafe);
            Assert.IsTrue(menuHasItems);
        }

        private KomodoCafe _cafe;
        private KomodoCafeRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new KomodoCafeRepository();
            _cafe = new KomodoCafe(1, "BurgerBuddy", "One Burger with another burger as its buddy.", 3.15, IngredientList.Meat);
            _repo.AddItemsToMenu(_cafe);
        }

        [TestMethod]
        public void GetByName_ShouldReturnCorrectItem()
        {
            KomodoCafe searchResult = _repo.GetMenuByName("BurgerBuddy");
            Assert.AreEqual(_cafe, searchResult);
        }

        [TestMethod]
        public void UpdateExistingMenuItems_ShouldShowUpdate()
        {
            _repo.UpdateExistingMenuItems("BurgerBuddy", new KomodoCafe(1, "BurgerHelper", "A burger who has a helper of lettuce", 3.25, IngredientList.Lettuce));
            Assert.AreEqual(_cafe.MealName, "BurgerHelper");
        }

        [TestMethod]
        public void DeleteExistingMenuItems_ShouldReturnTrue()
        {
            bool wasDeleted = _repo.DeleteExistingMenuItems("BurgerBuddy");
            Assert.IsTrue(wasDeleted);
        }
    }
}
