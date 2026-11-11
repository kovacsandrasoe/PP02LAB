using System.Diagnostics;

namespace PP02LAB.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new Client("http://localhost:5080", new HttpClient());
            List<Movie> movies = new List<Movie>();
            Task<ICollection<Movie>>[] tasks = new Task<ICollection<Movie>>[10];

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10; i++)
            {
                //movies.AddRange(await client.GetByPageAsync(i));
                int k = i;
                tasks[i] = Task.Run(() => client.GetByPageAsync(k));
            }

            Task.WaitAll(tasks);

            foreach (var item in tasks)
            {
                movies.AddRange(item.Result);
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
