using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadgeRepo
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<Door> DoorNames = new List<Door>();
        
        public Badge() { }
        public Badge(int badgeID, List<Door> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }
    }
    public class Door
    {
        public string DoorName { get; set; }

        public Door(string doorName)
        {
            DoorName = doorName;
        }
    }
}
