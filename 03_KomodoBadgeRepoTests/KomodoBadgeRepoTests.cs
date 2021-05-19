using _03_KomodoBadgeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_KomodoBadgeRepoTests
{
    [TestClass]
    public class KomodoBadgeRepoTests
    {
        private Badge _badge;
        private BadgeRepository _repository = new BadgeRepository();

        [TestInitialize]
        public void Arrange()
        {
            _repository.AddNewBadge(123, new List<Door> { new Door("A1") });
            
        }

        [TestMethod]
        public void ViewAllBadges_ShouldReturnBadgeDirectory()
        { 
           // Badge badge = new Badge();
            Dictionary<int, List<Door>> getAllBadges = _repository.ViewAllBadges();
            Assert.IsTrue(getAllBadges != null);
        }

        [TestMethod]
        public void AddNewBadge_ShouldReturnCorrectBadge()
        {
            int countBefore = _repository.ViewAllBadges().Count;
            _repository.AddNewBadge(122, new List<Door> { new Door("B2") });
            int countAfter = _repository.ViewAllBadges().Count;
            Assert.IsTrue(countAfter > countBefore);
            
            
        }

        [TestMethod]
        public void AddDoorToBadge_ShouldReturnNewDoor()
        {
            int countBefore = _repository.GetListOfDoor(123).Count;
            _repository.AddDoorToBadge(123, new Door("B3") );
            int countAfter = _repository.GetListOfDoor(123).Count;
            Assert.IsTrue(countBefore < countAfter);
        }

        [TestMethod]
        public void RemoveDoorFromBadge_ShouldRemoveCorrectDoor()
        {
            int countBefore = _repository.GetListOfDoor(123).Count;
            _repository.RemoveDoorFromBadge(123, new Door("A1"));
            int countAfter = _repository.GetListOfDoor(123).Count;
            Assert.IsTrue(countAfter < countBefore);
        }

        //[TestMethod]
        //public void DeleteExistingBadge_ShouldReturnDeleted()
        //{
        //    bool wasDeleted = _repo.DeleteExistingBadge(_badge);
        //    Assert.IsTrue(wasDeleted);
        //}
    }
}
