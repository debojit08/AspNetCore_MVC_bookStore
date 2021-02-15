using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Data
{
    public class LanguageTab
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public String Description { get; set; }

        public ICollection<Books> books { get; set; } //relationship of language table to Books class (id is primary key in language table reference to foreign key of languageId book table )
    }
}
