using Bible_Benchmark.Servicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible_Benchmark.Models
{
    public class Bible
    {
         static BibleDAO dAO = new BibleDAO();
        List<string> books = dAO.findAllBooks();
            

    public Bible()
        {
            
        }
    }
}
