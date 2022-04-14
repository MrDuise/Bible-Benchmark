using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible_Benchmark.Models
{
    public class Verse
    {
        public int BookId { get; set; }
        public int ChapterId { get; set; }

        public int VerseId { get; set; }
        public string BookName { get; set; }

        public string VerseText { get; set; }



        public Verse(int bookId, int chapterId, int verseId, string verseText)
        {
            BookId = bookId;
            ChapterId = chapterId;
            VerseId = verseId;
            
            VerseText = verseText;
        }
    }
}
