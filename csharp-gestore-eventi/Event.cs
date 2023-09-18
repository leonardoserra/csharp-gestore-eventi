using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Event
    {
        protected string title;
        protected DateTime date;
        protected int maxCapacity;
        protected int bookedSeatsQuantity;

        //constructor
        public Event(string title, DateTime date, int maxCapacity) {
            SetTitle(title);   
            SetDate(date);
            SetMaxCapacity(maxCapacity);
            this.bookedSeatsQuantity = 0;
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

        public int getMaxCapacity()
        {
            return this.maxCapacity;
        }

        public int getBookedSeatsQuantity()
        {
            return this.bookedSeatsQuantity;
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
            DateTime today = DateTime.Now;
            if (date < today)
                throw new Exception("La data assegnata è già passata! Inserire una data futura. Inserire una data valida in formato dd/MM/yyyy");

            this.date = date;
        }

        private void SetMaxCapacity(int maxCapacity)
        {
            if (maxCapacity <= 0)
                throw new Exception("Inserire un numero positivo per la capienza massima dell'evento.");
            
            this.maxCapacity = maxCapacity;
        
        }

        public override string ToString()
        {
            return $"Dettagli evento:\r\n\tData dell'evento: {this.date.ToString("dd/MM/yyyy")}\r\n\tTitolo: {this.title}";
        }

    }
}
