using Bible_Benchmark.Models;
using Bible_Benchmark.Servicies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bible_Benchmark.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }


        public List<Verse> updateBookName(List<Verse> verses)
        {
            BibleDAO dAO = new BibleDAO();
            List<Book> books = dAO.findAllBooks();

            for (int i = 0; i < verses.Count(); i++)
            {
                for (int a = 0; a < books.Count(); a++)
                {
                    if (books.ElementAt(a).BookId == verses.ElementAt(i).BookId)
                    {
                        verses.ElementAt(i).BookName = books.ElementAt(a).BookName;
                    }
                }
            }

            return verses;
        }

       public IActionResult Search(string searchText, string searchChoice)
        {
            BibleDAO dAO = new BibleDAO();
            List<Verse> verses = dAO.FindVersesBySearchString(searchText, searchChoice);

            verses = updateBookName(verses);

            return View("Search", verses);
        }
    }
}
