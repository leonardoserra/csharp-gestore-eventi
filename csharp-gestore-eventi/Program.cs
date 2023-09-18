using Microsoft.VisualBasic;

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
            string stringDate = Console.ReadLine();
            DateTime date = DateTime.ParseExact(stringDate,"dd/MM/yyyy",null);

            Console.WriteLine($"{title} {date.ToString("dd/MM/yyyy")}");
        }
    }
}