using _02_KomodoClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_KomodoClaimsRepoTests
{
    [TestClass]
    public class KomodoClaimRepoTests
    {
        [TestMethod]
        public void GetAllClaims_ShouldReturnClaimDirectory()
        {
            Claim claim = new Claim();
            ClaimRepository repository = new ClaimRepository();
            bool result = repository.AddNextClaim(claim);
            Assert.IsTrue(result);
        }

        private Claim _claim;
        private ClaimRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _claim = new Claim(4, ClaimType.Car, "Wreck on i-70", 20000.00d, new DateTime(2018, 4, 27), new DateTime(2018, 4, 28), true);
            _repo.AddNextClaim(_claim);
        }

        [TestMethod]
        public void GetNextClaim_ShouldReturnCorrectClaim()
        {
            Claim claimReturn = _repo.GetNextClaim();
            Assert.AreEqual(_claim, claimReturn);
        }

        [TestMethod]
        public void RemoveNextClaim_ShouldReturnCorrectBool()
        {
            bool wasRemoved = _repo.RemoveNextClaim();
            Assert.IsTrue(wasRemoved);
        }

        [TestMethod]
        public void AddNextClaim_ShouldReturnCorrectBool()
        {
            bool wasAdded = _repo.AddNextClaim(_claim);
            Assert.IsTrue(wasAdded);
        }
    }
}
