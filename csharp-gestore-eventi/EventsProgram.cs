using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class EventsProgram
    {
        protected string title;
        protected List<Event> events;

        public EventsProgram(string title)
        {
            this.title = title;
            events = new List<Event>();
        }

        //methods
        public void AddEvent(Event e) 
        { 
            this.events.Add(e);
        }

        public List<Event> SearchByDate(string dateString)
        {
            CultureInfo italianFormat = new CultureInfo("it-IT");
            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", italianFormat);
            List<Event> filteredEvents = new List<Event>();
            /*this.events.Select(e =>
            {
                if(e.GetDate() == date)
                    filteredEvents.Add((Event) e);
            }); */

            for(int i = 0; i < this.events.Count; i++)
            {
                if (events[i].GetDate() == date)
                    filteredEvents.Add(events[i]);
            }
            return filteredEvents;
        }
    }
}
