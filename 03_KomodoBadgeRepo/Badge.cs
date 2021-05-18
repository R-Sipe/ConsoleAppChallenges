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
        public string DoorA1 { get; set; }
        public string DoorA2 { get; set; }
        public string DoorA3 { get; set; }
        public string DoorA4 { get; set; }
        public string DoorA5 { get; set; }

        public Badge() { }
        public Badge(int badgeID, string doorA1, string doorA2, string doorA3, string doorA4, string doorA5)
        {
            BadgeID = badgeID;
            DoorA1 = doorA1;
            DoorA2 = doorA2;
            DoorA3 = doorA3;
            DoorA4 = doorA4;
            DoorA5 = doorA5;
        }
    }
}
