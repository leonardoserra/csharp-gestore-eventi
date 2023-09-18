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
        protected int reservedSeats;

        //constructor
        public Event(string title, DateTime date, int maxCapacity) {
            SetTitle(title);   
            SetDate(date);
            SetMaxCapacity(maxCapacity);
            this.reservedSeats = 0;
        }

        //getters
        public string GetTitle()
        {
            return this.title;
        }

        public DateTime GetDate()
        {
            return this.date;
        }

        public int GetMaxCapacity()
        {
            return this.maxCapacity;
        }

        public int GetReservedSeats()
        {
            return this.reservedSeats;
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


        //utility methods

        public void ReserveSeats(int seatsToReserve)
        {
            DateTime today = DateTime.Now;
            int availableSeats = this.maxCapacity - this.reservedSeats;
            if (this.date < today)
                throw new Exception("Impossibile prenotare ulteriori posti, evento già passato!");
            if(availableSeats<seatsToReserve)
                throw new Exception($"Posti liberi inferiori a quelli richiesti. Il numero di posti ancora liberi è {availableSeats}");
            if(availableSeats == 0)
                throw new Exception("Non è possibile effetturare prenotazioni per questo evento.");
            
            this.reservedSeats += seatsToReserve;
        }

        public void CancelReservation(int reservationToCancel)
        {
            DateTime today = DateTime.Now;
            int availableSeats = this.maxCapacity - this.reservedSeats;
            if (this.date < today)
                throw new Exception("Impossibile cancellare la prenotazione, evento già passato!");
            if (reservationToCancel > this.reservedSeats)
                throw new Exception($"Il numero di disdette supera il numero di prenotazioni attuale. Il numero di prenotazioni è {this.reservedSeats}");

            this.reservedSeats = this.maxCapacity - (availableSeats + reservationToCancel);
        }
        public override string ToString()
        {
            return $"\r\n\tData dell'evento: {this.date.ToString("dd/MM/yyyy")} - Titolo: {this.title}\r\n";
        }

    }
}
