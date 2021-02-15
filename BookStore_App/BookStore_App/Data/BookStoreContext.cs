using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//database connection

namespace BookStore_App.Data
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> option): base(option)
        {

        }
        //use the books entity class into this class to create tables
        public DbSet<Books> books { get; set; } // Books is a entity class and books is the table name
        public DbSet<LanguageTab> language { get; set; } // LanguageTab is a entity class and language is the table name

    }
}
