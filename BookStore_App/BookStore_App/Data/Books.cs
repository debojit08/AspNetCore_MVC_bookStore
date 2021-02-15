using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Data
{
    public class Books //database table column
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public String Author { get; set; }
        public String Categories { get; set; }

        public int Pages { get; set; }

        public int LanguageId { get; set; }

        public String Description { get; set; }
        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public LanguageTab Language { get; set; } //relationship to the language table and Language is the name of the relation
                                                  //LanguageID become foreign key relation to primary key of language table id               
    }
}
