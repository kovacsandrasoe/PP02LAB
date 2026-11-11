using System.Diagnostics;

namespace PP02LAB.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new Client("http://localhost:5080", new HttpClient());
            for (int i = 1972; i <= 2024; i++)
            {
                //outer variable trap
                int k = i;
                Task.Run(() => AvgRatingByYear(client, k));
            }

            Console.ReadLine();


        }

        static void AvgRatingByYear(Client client, int year)
        {
            var movies = client.GetByYear(year);
            if (movies.Any())
            {
                var avg = movies.Average(t => t.Rating);
                Console.WriteLine($"{year}: {avg}");
            }
        }

    }
}
