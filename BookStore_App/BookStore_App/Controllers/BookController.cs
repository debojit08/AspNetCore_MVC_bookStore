using BookStore_App.Models;
using BookStore_App.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly languageRepo _languageRepo = null;
        public BookController(BookRepository bookRepository, languageRepo languageRepo) //constructor and create dependencies in book constructor
        {
            _bookRepository = bookRepository;
            _languageRepo = languageRepo;
        }




        /*-------------------------display all the books to UI--------------------------*/
        public async Task<ViewResult> GetAllBooks()
        { 
            var data = await _bookRepository.GetAllBooks();
            return View(data);

        }
        /*----------------------------end all book display-----------------------------------*/






        /*------------------------------display single book to UI based on id------------------*/
        public async Task<ViewResult> getbook(int id)
        {
            var data= await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> searchBook(string bookName, string authorName)
        {
            return _bookRepository.SearchBooks(bookName,authorName);
        }
        /*------------------------------End display single book to UI based on id-----------------------*/











        /*---------------------------------get method (display)---------------------------------*/




        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId=0 ) //Razor view page of Add new Book UI
        {
            /*ViewBag.language = new List<String>() { "Hindi", "English", "Assamese" };*/ // to display the list of language in the dropdown
            var model = new BookModel();
            ViewBag.language = new SelectList(await _languageRepo.GetLanguage(), "Id","Name");
            ViewBag.IsSuccess = isSuccess; //for alerts
            ViewBag.BookId = bookId; //get the id 
            return View(model);
        }






        /*---------------post method (Sending data to server to store in database)----------------------*/




        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookmodel) //Action method ;when we submit all the book details..it will be hitting to bookmodel (view)
        {
            if (ModelState.IsValid)
            {
                var id = await _bookRepository.AddNewBook(bookmodel); //since return type is id, 
                if (id > 0) //after submitting ..clear the textboxes
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
                
            }
            ModelState.AddModelError("", "custom error messages");
            ViewBag.language = new SelectList(await _languageRepo.GetLanguage(), "Id", "Name");
            /*var list = new List<String>() { "HIndi", "English", "Assamese" };*//*selected language is sending to server to store in database*/

            return View();
        }
    }
}
