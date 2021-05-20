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
            MenuItem cafe = new MenuItem();
            MenuItemRepository repository = new MenuItemRepository();
            bool addResult = repository.AddItemsToMenu(cafe);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenu_ShouldReturnCorrectCollection()
        {
            MenuItem cafe = new MenuItem();
            MenuItemRepository repository = new MenuItemRepository();
            repository.AddItemsToMenu(cafe);
            List<MenuItem> menu = repository.GetAllMenuItems();
            bool menuHasItems = menu.Contains(cafe);
            Assert.IsTrue(menuHasItems);
        }

        private MenuItem _cafe;
        private MenuItemRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepository();
            _cafe = new MenuItem(1, "BurgerBuddy", "One Burger with another burger as its buddy.", 3.15M, new List<string> { "Meat", "Bun", "Cheese slice" });
            _repo.AddItemsToMenu(_cafe);
        }

        [TestMethod]
        public void GetByName_ShouldReturnCorrectItem()
        {
            MenuItem searchResult = _repo.GetMenuByName("BurgerBuddy");
            Assert.AreEqual(_cafe, searchResult);
        }

        [TestMethod]
        public void UpdateExistingMenuItems_ShouldShowUpdate()
        {
            _repo.UpdateExistingMenuItems("BurgerBuddy", new MenuItem(1, "BurgerHelper", "A burger who has a helper of lettuce", 3.25M, new List<string> { "Meat", "Bun", "Cheese slice"}));
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
