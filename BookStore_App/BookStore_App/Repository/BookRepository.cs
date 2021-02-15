using BookStore_App.Data;
using BookStore_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        /*-------------------------for insertion data to the database------------------*/
        public async Task<int> AddNewBook(BookModel model) 
        {
            var newBook = new Books() //Books is entity
            {
                Author = model.Author,
                Title = model.Title,
                Categories = model.Categories,
                Description = model.Description,
                LanguageId = model.LanguageId,
                Pages = model.Pages,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
            await _context.books.AddAsync(newBook); //books is table name
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        /*----------------------------------database end----------------------------*/

        /*------------------------------------display data(all books) from database------------------*/
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author=book.Author,
                        Title=book.Title,
                        Id=book.Id,
                        Description=book.Description,
                        LanguageId=book.LanguageId,
                        Pages=book.Pages,
                        Categories=book.Categories

                    });

                }
            }
            return books;
        }
        /*------------------------------end display data from database-------------------------*/

        /*--------------------------------display single book based on id from database-------------------*/
        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.books.Where(x => x.Id == id)
            .Select(singlebook => new BookModel()
            {
                Author = singlebook.Author,
                Title = singlebook.Title,
                Id = singlebook.Id,
                Description = singlebook.Description,
                LanguageId = singlebook.LanguageId,
                languageName = singlebook.Language.Name,
                Pages = singlebook.Pages,
                Categories = singlebook.Categories
            }).FirstOrDefaultAsync();
            
        }
        /*--------------------------------------display single book based on id from database--------------------------*/
        public List<BookModel> SearchBooks(string title, string authorName)
        {
            return null;
        }
        /*private List<BookModel> DataSource() //datasouece -> data come from private section
        {
            return new List<BookModel>()
            {
                new BookModel(){ Id=1,Title="MVC",Author="paul",Categories="Programming",Pages=342,Language="English",Description="This is MVC Programming"},
                new BookModel(){ Id=2,Title="java",Author="paul",Categories="Programming",Pages=372,Language="English",Description="This is Java Programming"},
                new BookModel(){ Id=3,Title="c++",Author="paul",Categories="Programming",Pages=543,Language="English",Description="This is C++ Programming"},
            };
        }*/

    }
}
