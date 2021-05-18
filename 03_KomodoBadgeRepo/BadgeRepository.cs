using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadgeRepo
{
    public class BadgeRepository // Key value pairs for dictionary
    {
        private readonly Dictionary<int, List<Door>> _badgeDirectory = new Dictionary<int, List<Door>>();

        public Dictionary<int, List<Door>> ViewAllBadges()
        {
            return _badgeDirectory;
        }

        public void AddNewBadge(int key, List<Door> value)
        {
            _badgeDirectory.Add(key, value);
        }

        public bool UpdateExistingBadge()
        {

        }

        public bool DeleteExistingBadge()
        {

        }
    }
}
