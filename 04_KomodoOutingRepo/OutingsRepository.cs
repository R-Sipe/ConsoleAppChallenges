using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KomodoOutingRepo
{
    public class OutingsRepository
    {
        private List<Outings> _outingsDirectory = new List<Outings>();

        public List<Outings> GetAllOutings()
        {
            return _outingsDirectory;
        }

        public bool AddOutingToList(Outings newOutings)
        {
            int startingCount = _outingsDirectory.Count;
            _outingsDirectory.Add(newOutings);
            bool addedOutings = (_outingsDirectory.Count > startingCount) ? true : false;
            return addedOutings;


        }
    }
}
