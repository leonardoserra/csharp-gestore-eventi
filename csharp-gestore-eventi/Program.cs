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
                bool managingEvents = true;
                while (managingEvents)
                {
                List<Event> events = new List<Event>(eventQuantity);
                for (int i = 0; i < events.Count; i++)
                {
                    try
                    {
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
                    


                    Event evento1 = new Event(title, date, maxCapacity);


                    EventsProgram programma = new EventsProgram("provaProgrammaEventi");
                    programma.AddEvent(evento1);

                    List<Event> listaFiltrata = programma.SearchByDate(stringDate);
                    string infoProgram = EventsProgram.ListEventsInfo(programma.Events);
                    //Console.WriteLine(infoProgram);
                    string infoFilteredProgram = EventsProgram.ListEventsInfo(listaFiltrata);
                    //Console.WriteLine(infoFilteredProgram);
                    //Console.WriteLine("Numero eventi in programma:" + programma.EventsQuantity());
                    Console.WriteLine(programma.ProgramDetails());

                    programma.DismissAllEvents();
                    //Console.WriteLine("Numero eventi in programma:" + programma.EventsQuantity());


                    Console.WriteLine(programma.ProgramDetails());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}