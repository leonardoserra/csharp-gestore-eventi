using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Event
    {
        private string? title;
        private DateTime date;
        private int maxCapacity;
        private int bookedSeatsQuantity;

        //constructor
        public Event() { 
            //TODO
        }
        //getters
        public string GetTitle()
        {
            return this.title;
        }

        public DateTime getDate()
        {
            return this.date;
        }



        //setters

        public void SetTitle(string title) {
            if (title == "")
                throw new Exception("Titolo dell'evento mancante, inserirlo");
            else if (title == null)
                throw new Exception("Titolo dell'evento mancante, inserirlo");
            
            this.title = title;
        }
        public void SetDate(DateTime date)
        {
            DateTime dateTime = DateTime.Now;
            if (date < dateTime)
                throw new Exception("La data assegnata è già passata! Inserire una data futura. Inserire una data valida in formato dd/MM/yyyy");

            this.date = date;
        }
    }
}
