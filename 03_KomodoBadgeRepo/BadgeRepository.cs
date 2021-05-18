using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadgeRepo
{
    public class BadgeRepository // Key value pairs for dictionary
    {
        private readonly Dictionary<int, List<Door>> _badgeDirectory = new Dictionary<int, List<Door>>(); //
        

        public Dictionary<int, List<Door>> ViewAllBadges()
        {
            return _badgeDirectory;
        }

        public void AddNewBadge(int key, List<Door> value)
        {
            _badgeDirectory.Add(key, value);
        }

        public void AddDoorToBadge(int badgeID,Door doorToAdd)
        {
            //List<Door> doors = GetListOfDoor(badgeID);  hard way 
            //doors.Add(doorToAdd);
            foreach(KeyValuePair<int, List<Door>> existingDoors in _badgeDirectory)
            {
                if(existingDoors.Key == badgeID)
                {
                    existingDoors.Value.Add(doorToAdd);
                }
            }
        }

        public bool RemoveDoorFromBadge()
        {

        }

        public bool DeleteExistingBadge()
        {

        }

        public List<Door> GetListOfDoor(int badgeID)
        {
            foreach(KeyValuePair<int, List<Door>> doors in _badgeDirectory)
            {
                if(doors.Key == badgeID)
                {
                    return doors.Value;
                }
            }
            return null;
        }
    }
}
