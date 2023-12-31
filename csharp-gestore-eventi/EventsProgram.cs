﻿using System;
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
        public List<Event> Events { get; }

        public EventsProgram(string title)
        {
            this.title = title;
            Events = new List<Event>();
        }


        //static methods

        public static string ListEventsInfo(List<Event> eventsList)
        {
            string list = "";
            if (eventsList.Count > 0)
            {
                foreach (Event e in eventsList)
                {
                    list += (" " + e.ToString());
                }
                return list;
            }
            return "la lista è vuota";
        }
        //methods
        public void AddEvent(Event e) 
        { 
            this.Events.Add(e);
        }

        public List<Event> SearchByDate(string dateString)
        {
            CultureInfo italianFormat = new CultureInfo("it-IT");
            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", italianFormat);
            List<Event> filteredEvents = new List<Event>();

            for(int i = 0; i < this.Events.Count; i++)
            {
                if (Events[i].GetDate() == date)
                    filteredEvents.Add(Events[i]);
            }
            return filteredEvents;
        }

        public int EventsQuantity()
        {
            return this.Events.Count;
        }

        public void DismissAllEvents()
        {
            this.Events.Clear();
        }


        //todo
        public string ProgramDetails()
        {
            return $@"Programma {this.title}:
                    Lista eventi:
 
                    {ListEventsInfo(this.Events)}";
        }
    }
}
