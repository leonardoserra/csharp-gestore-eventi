using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Event
    {
        public string? Title { get; set; }
        public DateOnly Date { get; set; }
        public int MaxCapacity { get; private set; }
        public int BookedSeatsQuantity { get; private set; }
    }
}
