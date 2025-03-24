using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_Duolingo_
{
    public class Word
    {
        public string ForeignWord { get; set; } // Иностранное слово
        public string Translation { get; set; } // Перевод
        public string Category { get; set; } // Категория

        public Word(string foreign, string translation, string category)
        {
            ForeignWord = foreign;
            Translation = translation;
            Category = category;
        }
    }
}
