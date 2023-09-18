using Microsoft.VisualBasic;
using System.Globalization;

namespace csharp_gestore_eventi
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Per creare un evento compili i campi richiesti:\r\n\t");
            try
            {
                Console.Write("Titolo evento: ");
                string title = Console.ReadLine();

                Console.Write("Data evento in formato dd/MM/yyyy: ");
                CultureInfo italianFormat = new CultureInfo("it-IT");
                string stringDate = Console.ReadLine();
                DateTime date = DateTime.ParseExact(stringDate,"dd/MM/yyyy",italianFormat);

                Console.Write("Capacità massima di prenotazioni: ");
                int maxCapacity = int.Parse(Console.ReadLine());
                Event evento1 = new Event(title, date, maxCapacity);
                //Console.WriteLine(evento1);
                Event evento2 = new Event("Musica d'insieme", date, 389);
                //Console.WriteLine(evento2);


                EventsProgram programma = new EventsProgram("provaProgrammaEventi");
                programma.AddEvent(evento1);
                programma.AddEvent(evento2);

                List<Event> listaFiltrata = programma.SearchByDate(stringDate);
                EventsProgram.PrintListEvents(listaFiltrata);
                Console.WriteLine("Numero eventi in programma:" + programma.EventsQuantity());
                programma.DismissAllEvents();
                Console.WriteLine("Numero eventi in programma:" + programma.EventsQuantity());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}