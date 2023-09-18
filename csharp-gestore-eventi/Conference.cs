using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{   
    public class Conference : Event
    {
        private string relatorName;
        private float price;
        public Conference(string title, DateTime date, int maxCapacity, string relatorName, float price) : base(title, date, maxCapacity)
        {
            this.relatorName = relatorName;
            this.price = price;
        }


        public override string ToString()
        {
            return $"\r\n\tData dell'evento: {this.date.ToString("dd/MM/yyyy")} - Titolo: {this.title} - Relatore: {this.relatorName} - Prezzo: {this.price.ToString("0.00")}\r\n";
        }
    }
}
