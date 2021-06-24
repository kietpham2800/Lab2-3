using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "Hello Teacher - University: " + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("Professional ASP.NET MVC5 - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1,"HTML & CSS3 The complete Manual","Author Name Book 1","/Content/Images/hinh1.jpg"));
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 2", "/Content/Images/hinh2.jpg"));
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 3", "/Content/Images/hinh3.jpg"));
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/hinh1.jpg"));
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 2", "/Content/Images/hinh2.jpg"));
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 3", "/Content/Images/hinh3.jpg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if(b.Id==id)
                {
                    book = b;
                    break;
                }
            }
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost,ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Tittle, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/hinh1.jpg"));
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 2", "/Content/Images/hinh2.jpg"));
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 3", "/Content/Images/hinh3.jpg"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Tiitle = Tittle;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
           
            return View("ListBookModel",books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost,ActionName("CeateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Tittle,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 1", "/Content/Images/hinh1.jpg"));
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 2", "/Content/Images/hinh2.jpg"));
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 3", "/Content/Images/hinh3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    //Thêm sách
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }

            return View("ListBookModel", books);
        }
      
    }
}