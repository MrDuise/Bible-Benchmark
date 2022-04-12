using Bible_Benchmark.Models;
using Bible_Benchmark.Servicies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible_Benchmark.Controllers
{
    public class BibleController : Controller
    {
        public IActionResult Index()
        {
            BibleDAO dAO = new BibleDAO();
            Console.WriteLine(dAO.findAllBooks());
            return View();
        }
    }
}
