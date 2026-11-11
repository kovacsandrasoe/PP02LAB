using Microsoft.AspNetCore.Mvc;
using PP02LAB.Server.Models;

namespace PP02LAB.Server.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MovieController : ControllerBase
    {
        static Random r = new Random();
        static List<Movie> movies = new List<Movie>();

        static MovieController()
        {
            movies = new List<Movie>
            {
                new Movie(1, "The Shawshank Redemption", new DateTime(1994, 9, 23), 10),
                new Movie(2, "The Godfather", new DateTime(1972, 3, 24), 10),
                new Movie(3, "The Dark Knight", new DateTime(2008, 7, 18), 9),
                new Movie(4, "Pulp Fiction", new DateTime(1994, 10, 14), 9),
                new Movie(5, "Forrest Gump", new DateTime(1994, 7, 6), 9),
                new Movie(6, "Inception", new DateTime(2010, 7, 16), 9),
                new Movie(7, "Fight Club", new DateTime(1999, 10, 15), 9),
                new Movie(8, "The Matrix", new DateTime(1999, 3, 31), 9),
                new Movie(9, "Goodfellas", new DateTime(1990, 9, 19), 9),
                new Movie(10, "Se7en", new DateTime(1995, 9, 22), 9),
                new Movie(11, "Interstellar", new DateTime(2014, 11, 7), 9),
                new Movie(12, "Gladiator", new DateTime(2000, 5, 5), 9),
                new Movie(13, "The Green Mile", new DateTime(1999, 12, 10), 9),
                new Movie(14, "Saving Private Ryan", new DateTime(1998, 7, 24), 9),
                new Movie(15, "The Silence of the Lambs", new DateTime(1991, 2, 14), 9),
                new Movie(16, "The Departed", new DateTime(2006, 10, 6), 9),
                new Movie(17, "Whiplash", new DateTime(2014, 10, 10), 9),
                new Movie(18, "The Prestige", new DateTime(2006, 10, 20), 9),
                new Movie(19, "The Lion King", new DateTime(1994, 6, 24), 9),
                new Movie(20, "Back to the Future", new DateTime(1985, 7, 3), 9),
                new Movie(21, "Titanic", new DateTime(1997, 12, 19), 8),
                new Movie(22, "Avatar", new DateTime(2009, 12, 18), 8),
                new Movie(23, "Jurassic Park", new DateTime(1993, 6, 11), 9),
                new Movie(24, "The Terminator", new DateTime(1984, 10, 26), 8),
                new Movie(25, "Terminator 2: Judgment Day", new DateTime(1991, 7, 3), 9),
                new Movie(26, "Alien", new DateTime(1979, 5, 25), 9),
                new Movie(27, "Aliens", new DateTime(1986, 7, 18), 9),
                new Movie(28, "Blade Runner", new DateTime(1982, 6, 25), 9),
                new Movie(29, "Blade Runner 2049", new DateTime(2017, 10, 6), 9),
                new Movie(30, "Dune", new DateTime(2021, 10, 22), 8),
                new Movie(31, "Dune: Part Two", new DateTime(2024, 3, 1), 9),
                new Movie(32, "Oppenheimer", new DateTime(2023, 7, 21), 9),
                new Movie(33, "Barbie", new DateTime(2023, 7, 21), 7),
                new Movie(34, "Joker", new DateTime(2019, 10, 4), 9),
                new Movie(35, "The Batman", new DateTime(2022, 3, 4), 8),
                new Movie(36, "Iron Man", new DateTime(2008, 5, 2), 8),
                new Movie(37, "The Avengers", new DateTime(2012, 5, 4), 8),
                new Movie(38, "Avengers: Infinity War", new DateTime(2018, 4, 27), 9),
                new Movie(39, "Avengers: Endgame", new DateTime(2019, 4, 26), 9),
                new Movie(40, "Spider-Man: No Way Home", new DateTime(2021, 12, 17), 8),
                new Movie(41, "Star Wars: A New Hope", new DateTime(1977, 5, 25), 9),
                new Movie(42, "The Empire Strikes Back", new DateTime(1980, 5, 21), 9),
                new Movie(43, "Return of the Jedi", new DateTime(1983, 5, 25), 8),
                new Movie(44, "The Phantom Menace", new DateTime(1999, 5, 19), 7),
                new Movie(45, "Revenge of the Sith", new DateTime(2005, 5, 19), 8),
                new Movie(46, "The Force Awakens", new DateTime(2015, 12, 18), 8),
                new Movie(47, "Rogue One", new DateTime(2016, 12, 16), 8),
                new Movie(48, "The Lord of the Rings: The Fellowship of the Ring", new DateTime(2001, 12, 19), 9),
                new Movie(49, "The Lord of the Rings: The Two Towers", new DateTime(2002, 12, 18), 9),
                new Movie(50, "The Lord of the Rings: The Return of the King", new DateTime(2003, 12, 17), 10),
                new Movie(51, "The Hobbit: An Unexpected Journey", new DateTime(2012, 12, 14), 8),
                new Movie(52, "The Hobbit: The Desolation of Smaug", new DateTime(2013, 12, 13), 8),
                new Movie(53, "The Hobbit: The Battle of the Five Armies", new DateTime(2014, 12, 17), 7),
                new Movie(54, "Harry Potter and the Philosopher's Stone", new DateTime(2001, 11, 16), 8),
                new Movie(55, "Harry Potter and the Chamber of Secrets", new DateTime(2002, 11, 15), 8),
                new Movie(56, "Harry Potter and the Prisoner of Azkaban", new DateTime(2004, 6, 4), 9),
                new Movie(57, "Harry Potter and the Goblet of Fire", new DateTime(2005, 11, 18), 8),
                new Movie(58, "Harry Potter and the Order of the Phoenix", new DateTime(2007, 7, 11), 8),
                new Movie(59, "Harry Potter and the Half-Blood Prince", new DateTime(2009, 7, 15), 8),
                new Movie(60, "Harry Potter and the Deathly Hallows: Part 1", new DateTime(2010, 11, 19), 8),
                new Movie(61, "Harry Potter and the Deathly Hallows: Part 2", new DateTime(2011, 7, 15), 9),
                new Movie(62, "Pirates of the Caribbean: The Curse of the Black Pearl", new DateTime(2003, 7, 9), 9),
                new Movie(63, "Pirates of the Caribbean: Dead Man's Chest", new DateTime(2006, 7, 7), 8),
                new Movie(64, "Pirates of the Caribbean: At World's End", new DateTime(2007, 5, 25), 8),
                new Movie(65, "Indiana Jones and the Raiders of the Lost Ark", new DateTime(1981, 6, 12), 9),
                new Movie(66, "Indiana Jones and the Last Crusade", new DateTime(1989, 5, 24), 9),
                new Movie(67, "The Wolf of Wall Street", new DateTime(2013, 12, 25), 9),
                new Movie(68, "The Social Network", new DateTime(2010, 10, 1), 8),
                new Movie(69, "The Big Short", new DateTime(2015, 12, 11), 8),
                new Movie(70, "The Imitation Game", new DateTime(2014, 11, 28), 8),
                new Movie(71, "A Beautiful Mind", new DateTime(2001, 12, 21), 9),
                new Movie(72, "The Pursuit of Happyness", new DateTime(2006, 12, 15), 8),
                new Movie(73, "Catch Me If You Can", new DateTime(2002, 12, 25), 9),
                new Movie(74, "The Terminal", new DateTime(2004, 6, 18), 8),
                new Movie(75, "Cast Away", new DateTime(2000, 12, 22), 8),
                new Movie(76, "The Truman Show", new DateTime(1998, 6, 5), 9),
                new Movie(77, "Eternal Sunshine of the Spotless Mind", new DateTime(2004, 3, 19), 9),
                new Movie(78, "La La Land", new DateTime(2016, 12, 9), 8),
                new Movie(79, "The Notebook", new DateTime(2004, 6, 25), 8),
                new Movie(80, "The Great Gatsby", new DateTime(2013, 5, 10), 8),
                new Movie(81, "Parasite", new DateTime(2019, 5, 30), 9),
                new Movie(82, "Oldboy", new DateTime(2003, 11, 21), 9),
                new Movie(83, "Train to Busan", new DateTime(2016, 7, 20), 8),
                new Movie(84, "Everything Everywhere All at Once", new DateTime(2022, 3, 25), 8),
                new Movie(85, "The Grand Budapest Hotel", new DateTime(2014, 3, 7), 9),
                new Movie(86, "Moonrise Kingdom", new DateTime(2012, 5, 25), 8),
                new Movie(87, "The French Dispatch", new DateTime(2021, 10, 22), 7),
                new Movie(88, "Knives Out", new DateTime(2019, 11, 27), 8),
                new Movie(89, "Glass Onion", new DateTime(2022, 12, 23), 8),
                new Movie(90, "Gone Girl", new DateTime(2014, 10, 3), 9),
                new Movie(91, "Shutter Island", new DateTime(2010, 2, 19), 9),
                new Movie(92, "Prisoners", new DateTime(2013, 9, 20), 9),
                new Movie(93, "Nightcrawler", new DateTime(2014, 10, 31), 8),
                new Movie(94, "Zodiac", new DateTime(2007, 3, 2), 9),
                new Movie(95, "No Country for Old Men", new DateTime(2007, 11, 9), 9),
                new Movie(96, "There Will Be Blood", new DateTime(2007, 12, 26), 9),
                new Movie(97, "Django Unchained", new DateTime(2012, 12, 25), 9),
                new Movie(98, "Inglourious Basterds", new DateTime(2009, 8, 21), 9),
                new Movie(99, "Once Upon a Time in Hollywood", new DateTime(2019, 7, 26), 8),
                new Movie(100, "The Hateful Eight", new DateTime(2015, 12, 25), 8)
            };

        }

        [HttpGet("page/{page}")]
        public List<Movie> GetByPage(int page)
        {
            var delayedTask = Task.Delay(r.Next(100, 700));
            delayedTask.Wait();
            return movies.Skip(page * 10).Take(10).ToList();
        }

        [HttpGet("year/{year}")]
        public List<Movie> GetByYear(int year)
        {
            //1972-2024
            var delayedTask = Task.Delay(r.Next(10, 50));
            delayedTask.Wait();
            return movies.Where(t => t.Release.Year == year).ToList(); ;
        }
    }
}
