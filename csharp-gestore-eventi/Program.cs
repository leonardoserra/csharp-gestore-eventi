using Microsoft.VisualBasic;
using System.Globalization;

namespace csharp_gestore_eventi
{
    public class Program
    {
        static void Main(string[] args)
        {
            CultureInfo italianFormat = new CultureInfo("it-IT");
            bool eventCreationIncomplete = true;
            while (eventCreationIncomplete)
            {
                try
                {
                    Console.WriteLine($"Creazione evento singolo:");
                    Console.Write($"Titolo evento: ");
                    string title = Console.ReadLine();

                    Console.Write("Data evento in formato dd/MM/yyyy: ");
                    string stringDate = Console.ReadLine();
                    DateTime date = DateTime.ParseExact(stringDate, "dd/MM/yyyy", italianFormat);

                    Console.Write("Capacità massima di prenotazioni: ");
                    int maxCapacity = int.Parse(Console.ReadLine());
                    Event e = new Event(title, date, maxCapacity);

                    Console.WriteLine($"Quante prenotazioni vuoi effettuare? Posti disponibili {e.GetMaxCapacity().ToString()}. Digita un numero: ");
                    int reservationRequest = int.Parse(Console.ReadLine());
                    e.ReserveSeats(reservationRequest);
                    Console.WriteLine();
                    bool stillCancelling = true;
                    while (stillCancelling)
                    {
                        Console.WriteLine($"Posti prenotati: {e.GetReservedSeats().ToString()}");
                        Console.WriteLine($"Posti liberi: {(e.GetMaxCapacity() - e.GetReservedSeats()).ToString()}");
                        Console.WriteLine("Vuoi disdire delle prenotazioni? s/n");
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "n" || answer == "no")
                        {
                            Console.WriteLine("Ok gestione evento terminata! Uscita in corso...");
                            stillCancelling = false;
                            break;
                        }
                        Console.WriteLine($"Quante prenotazioni vuoi disdire? Posti disponibili {(e.GetMaxCapacity() - e.GetReservedSeats()).ToString()}. Digita un numero: ");
                        int cancellationRequest = int.Parse(Console.ReadLine());
                        e.CancelReservation(cancellationRequest);
                    }
                    eventCreationIncomplete = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;

                }
            }


            try
            {
                Console.WriteLine();
                Console.WriteLine("---------------------SECONDA PARTE-------------------------");
                Console.Write("Inizializzazione, che nome vuoi dare al Programma di Eventi? Digita: ");
                string programTitle = Console.ReadLine();
                EventsProgram customProgram = new EventsProgram(programTitle);
                Console.Write($"Bene! Programma {programTitle} creato! Quanti eventi andrai ad aggiungere al programma? Digita un numero: ");
                int eventQuantity = int.Parse(Console.ReadLine());
                List<Event> events = new List<Event>();
                
                    for (int i = 0; i < eventQuantity; i++)
                    {
                        try
                        {
                            Console.WriteLine($"Creazione evento n.{i + 1}");
                            Console.Write($"Titolo evento: ");
                            string title = Console.ReadLine();

                            Console.Write("Data evento in formato dd/MM/yyyy: ");
                            string stringDate = Console.ReadLine();
                            DateTime date = DateTime.ParseExact(stringDate, "dd/MM/yyyy", italianFormat);

                            Console.Write("Capacità massima di prenotazioni: ");
                            int maxCapacity = int.Parse(Console.ReadLine());
                            Event e = new Event(title, date, maxCapacity);
                            customProgram.AddEvent(e);

                        }catch (Exception ex){
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Ri assegna i dati all evento");
                            i--;
                            continue;
                        }

                    }
                    Console.WriteLine();
                    
                int totalEventsInActualProgram = customProgram.EventsQuantity();
                Console.WriteLine($"Ci sono ben {totalEventsInActualProgram} eventi in programma!");
                string eventsList = customProgram.ProgramDetails();
                Console.WriteLine(eventsList);
                Console.WriteLine("Cerca uno o piú eventi in una data specifica, digita gg/mm/aaaa: ");
                string requestedDate = Console.ReadLine();
                List<Event> eventsByDate = customProgram.SearchByDate(requestedDate);
                string eventListByDate = EventsProgram.ListEventsInfo(eventsByDate);
                Console.WriteLine(eventListByDate);


                //BONUS conferenza
                Console.WriteLine();
                Console.WriteLine("___________________________BONUS_________________________________");

                Console.WriteLine($"Inserisci una conferenza al tuo programma {programTitle}");
                Console.Write($"Titolo conferenza: ");
                string conferenceTitle = Console.ReadLine();

                Console.Write("Data conferenza in formato dd/MM/yyyy: ");
                string stringConferenceDate = Console.ReadLine();
                DateTime conferenceDate = DateTime.ParseExact(stringConferenceDate, "dd/MM/yyyy", italianFormat);

                Console.Write("Capacità massima di prenotazioni per la conferenza: ");
                int maxConferenceCapacity = int.Parse(Console.ReadLine());

                Console.Write("Nome del relatore: ");
                string relatorName = Console.ReadLine();

                Console.Write("Prezzo Conferenza: ");
                float conferencePrice = float.Parse(Console.ReadLine());

                Conference conference1 = new Conference(conferenceTitle, conferenceDate, maxConferenceCapacity, relatorName, conferencePrice);
                customProgram.AddEvent(conference1);

                totalEventsInActualProgram = customProgram.EventsQuantity();
                Console.WriteLine($"Ci sono ben {totalEventsInActualProgram} eventi e conferenze in programma!");
                string eventsAndConferencesList = customProgram.ProgramDetails();
                Console.WriteLine(eventsAndConferencesList);

                customProgram.DismissAllEvents();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}