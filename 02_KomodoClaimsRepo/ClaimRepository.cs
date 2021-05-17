using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsRepo
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimDirectory = new Queue<Claim>();

        public Queue<Claim> GetAllClaims()
        {
            return _claimDirectory;
        }

        public Claim GetNextClaim()
        {
            return _claimDirectory.Peek();
            
        }

        public bool RemoveNextClaim()
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Dequeue();
            bool isDeleted = (_claimDirectory.Count < startingCount) ? true : false;
            return isDeleted;
        }

        public bool AddNextClaim(Claim newClaim)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Enqueue(newClaim);
            bool addedClaim = (_claimDirectory.Count > startingCount) ? true : false;
            return addedClaim;
        }
    }
}
