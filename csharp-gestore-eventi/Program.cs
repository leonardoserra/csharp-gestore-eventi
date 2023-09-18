using Microsoft.VisualBasic;
using System.Globalization;

namespace csharp_gestore_eventi
{
    public class Program
    {
        static void Main(string[] args)
        {
            CultureInfo italianFormat = new CultureInfo("it-IT");
            try
            {
                Console.Write("Inizializzazione, che nome vuoi dare al Programma di Eventi? Digita: ");
                string programTitle = Console.ReadLine();
                EventsProgram customProgram = new EventsProgram(programTitle);
                Console.Write($"Bene! Programma {programTitle} creato! Quanti eventi andrai ad aggiungere al programma? Digita un numero: ");
                int eventQuantity = int.Parse(Console.ReadLine());
                List<Event> events = new List<Event>(eventQuantity);
                bool managingEvents = true;
                //while (managingEvents)
                //{
                    for (int i = 0; i < eventQuantity; i++)
                    {
                        try
                        {
                            Console.WriteLine($"Creazione evento n.{i + 1}");
                            Console.Write($"Titolo evento n.{i+1}: ");
                            string title = Console.ReadLine();

                            Console.Write("Data evento in formato dd/MM/yyyy: ");
                            string stringDate = Console.ReadLine();
                            DateTime date = DateTime.ParseExact(stringDate, "dd/MM/yyyy", italianFormat);

                            Console.Write("Capacità massima di prenotazioni: ");
                            int maxCapacity = int.Parse(Console.ReadLine());
                            events[i] = new Event(title, date, maxCapacity);

                        }catch (Exception ex){
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Ri assegna i dati all evento");
                            i--;
                            continue;
                        }

                    }
                    Console.WriteLine();
                //}
                    
                int totalEventsInActualProgram = customProgram.EventsQuantity();
                Console.WriteLine($"Ci sono ben {totalEventsInActualProgram} eventi in programma!");
                customProgram.ProgramDetails();

                Console.WriteLine("Cerca uno o piú eventi in una data specifica, digita gg/mm/aaaa: ");
                string requestedDate = Console.ReadLine();
                List<Event> eventsByDate = customProgram.SearchByDate(requestedDate);
                string eventListByDate = EventsProgram.ListEventsInfo(eventsByDate);
                Console.WriteLine(eventListByDate);
                customProgram.DismissAllEvents();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}