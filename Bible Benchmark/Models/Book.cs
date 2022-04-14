using Bible_Benchmark.Servicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible_Benchmark.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }

        public Book(int bookId, string bookName)
        {
            BookId = bookId;
            BookName = bookName;
        }
    }
}
