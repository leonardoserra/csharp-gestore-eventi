using Microsoft.VisualBasic;
using System.Globalization;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Per creare un evento compili i campi richiesti:\r\n\t");
            
            Console.Write("Titolo evento: ");
            string title = Console.ReadLine();

            Console.Write("Data evento in formato dd/MM/yyyy: ");
            CultureInfo italianFormat = new CultureInfo("it-IT");
            string stringDate = Console.ReadLine();
            DateTime date = DateTime.ParseExact(stringDate,"dd/MM/yyyy",italianFormat);

            Console.Write("Capacità massima di prenotazioni: ");
            int maxCapacity = int.Parse(Console.ReadLine());

            Event evento1 = new Event(title, date, maxCapacity);
            Console.WriteLine(evento1);

        }
    }
}