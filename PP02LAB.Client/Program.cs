using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PP02LAB.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            object lockObject = new object();
            Console.SetWindowSize(100, 200);
            var client = new Client("http://localhost:5080", new HttpClient());
            List<Task> tasks = new List<Task>();
            for (int i = 1972; i <= 2024; i++)
            {
                //outer variable trap
                int k = i;
                tasks.Add(AvgRatingByYear(client,k, lockObject));
            }

            Task.WaitAll(tasks.ToArray());

            Console.ReadLine();


        }

        static async Task AvgRatingByYear(Client client, int year, object lockObject)
        {
            var movies = await client.GetByYearAsync(year);
            if (movies.Any())
            {
                var avg = movies.Average(t => t.Rating);
                Monitor.Enter(lockObject);
                Console.SetCursorPosition(0, year - 1972);
                Console.WriteLine($"{year}: {avg}");
                Monitor.Exit(lockObject);
            }
        }

    }
}
