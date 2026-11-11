using System.Diagnostics;

namespace PP02LAB.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new Client("http://localhost:5080", new HttpClient());
            List<Movie> movies = new List<Movie>();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 1; i <= 10; i++)
            {
                movies.AddRange(client.GetByPage(i));
            }
            sw.Stop();

            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie.Title);
            }
            Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds} ms");

            Console.ReadLine();

        }
    }
}
