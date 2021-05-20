using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KomodoOutingRepo
{
    public enum EventType { Golf=1, Bowling, AmusmentPark, Concert}
    public class Outings
    {
        public int Attendance { get; set; }
        public EventType EventType { get; set; }
        public DateTime Date { get; set; }
        public double CostPerPerson { get; set; }
        public double CostPerEvent { get; set; }

        public Outings() { }
        public Outings(int attendance, EventType eventType, DateTime date, double costPerPerson, double costPerEvent)
        {
            Attendance = attendance;
            EventType = eventType;
            Date = date;
            CostPerPerson = costPerPerson;
            CostPerEvent = costPerEvent;
        }
    }
}
