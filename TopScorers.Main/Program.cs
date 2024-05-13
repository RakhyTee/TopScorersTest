using Application.Services;
using Infrastructure.Services;

namespace TopScorers.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.Write("Do you want to select a file to process scores? Y/N: ");
            var answer = Console.ReadLine();

            if (answer?.ToUpper() != "Y")
            {
                Console.WriteLine("No file selected. Exiting...");
                return;
            }

            Console.Write("Please enter the file path: ");
            var filePath = Console.ReadLine();


            var service = new StudentScoreService(filePath);
            var scoreHandler = new GetTopScorersHandler(service);
            var topScorers = scoreHandler.GetTopScorers(2);

            Console.WriteLine("\nTop scorers");
            foreach (var scorer in topScorers)
            {
                Console.WriteLine(scorer);
            }

            Console.ReadKey();
        }
    }
}
