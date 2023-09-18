using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{   
    public class Conference : Event
    {
        public string RelatorName { get; set; }
        public float Price { get; set; }
        public Conference(string title, DateTime date, int maxCapacity, string relatorName, float price) : base(title, date, maxCapacity)
        {
            this.RelatorName = relatorName;
            this.Price = price;
        }


        public override string ToString()
        {
            return $"\r\n\tData dell'evento: {this.date.ToString("dd/MM/yyyy")} - Titolo: {this.title} - Relatore: {this.RelatorName} - Prezzo: {this.Price.ToString("0.00")}\r\n";
        }
    }
}
