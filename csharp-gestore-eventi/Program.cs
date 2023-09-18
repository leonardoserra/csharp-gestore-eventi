using Microsoft.VisualBasic;
using System.Globalization;

namespace csharp_gestore_eventi
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inizializzazione, che nome vuoi dare al Programma di Eventi? Digita: ");
            string programTitle = Console.ReadLine();
            Console.Write($"Bene! Programma {programTitle} creato! Quanti eventi andrai ad aggiungere al programma? Digita un numero: ");
            EventsProgram customProgram = new EventsProgram(programTitle);
            
            
            int eventQuantity = int.Parse(Console.ReadLine());
            Console.WriteLine();



            try
            {
                bool managingEvents = true;
                while (managingEvents)
                {
                    

                    Console.Write("Titolo evento: ");
                    string title = Console.ReadLine();

                    Console.Write("Data evento in formato dd/MM/yyyy: ");
                    CultureInfo italianFormat = new CultureInfo("it-IT");
                    string stringDate = Console.ReadLine();
                    DateTime date = DateTime.ParseExact(stringDate, "dd/MM/yyyy", italianFormat);

                    Console.Write("Capacità massima di prenotazioni: ");
                    int maxCapacity = int.Parse(Console.ReadLine());
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