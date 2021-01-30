using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Store1.Models;
using Book_Store1.Models.Repositories;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Book_Store1.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookStoreRepository<Book> bookStoreRepository1;
        private readonly IBookStoreRepository<Author> AuthorStoreRepository1;
        
        private readonly IHostingEnvironment hostingEnvironment;

        
        public BookController(IBookStoreRepository<Book> bookStoreRepository, 
            IBookStoreRepository<Author> AuthorStoreRepository,
            IHostingEnvironment   hostingEnvironment)
        {
            this.bookStoreRepository1 = bookStoreRepository;
            this.AuthorStoreRepository1 = AuthorStoreRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        

        // GET: BookController
        public ActionResult Index()
        {
            var book = bookStoreRepository1.list();
            
            return View(book);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = bookStoreRepository1.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookAuthorViewModel
            {
                Authors=myList()

            };
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel model)
        {
            string filename = string.Empty;
            if (model.MyFile!=null)
            {
                string uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                filename = model.MyFile.FileName;
                string FullPath = Path.Combine(uploads, filename);
                model.MyFile.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.AuthorId == -1)
                    {
                        ViewBag.message = "please choose an author";
                        var vmodel = new BookAuthorViewModel
                        {
                            Authors = myList()

                        };
                        return View(vmodel);
                    }
                    Book book = new Book
                    {
                        Id = model.BookId,
                        Title = model.Title,
                        Describtion = model.Descrebtion,
                        Author = AuthorStoreRepository1.Find(model.AuthorId),
                        My_ImageUrl = filename
                    };
                    bookStoreRepository1.Add(book);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            var smodel = new BookAuthorViewModel
            {
                Authors = myList()

            };
            ModelState.AddModelError("", " please insert all the fields");
            return View(smodel);
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookStoreRepository1.Find(id);
            var authorId1 = book.Author == null ? book.Author.Id = 0 : book.Author.Id;

            var model = new BookAuthorViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                Descrebtion = book.Describtion,
                AuthorId = authorId1,
                Authors = AuthorStoreRepository1.list().ToList(),
                ImgUrl = book.My_ImageUrl            
            };
            return View(model);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAuthorViewModel model)
        {
            try
            {
                string OldPath = "test path";
                string filename = string.Empty;
                filename = model.ImgUrl;
                if (model.MyFile != null)
                {
                    OldPath = "test path11";
                    string uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                    filename = model.MyFile.FileName;
                    string FullPath = Path.Combine(uploads, filename);
                    string OldName = bookStoreRepository1.Find(model.BookId).My_ImageUrl;
                     OldPath = Path.Combine(uploads, OldName);
                   // System.IO.File.Delete(OldPath);
                    model.MyFile.CopyTo(new FileStream(FullPath, FileMode.Create));

                }
                Book book = new Book
                {
                    Id = model.BookId,
                    Title = model.Title,
                    Describtion = model.Descrebtion,
                    Author = AuthorStoreRepository1.Find(model.AuthorId),
                    My_ImageUrl = filename

                };
                bookStoreRepository1.Update(id,book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookStoreRepository1.Find(id);
            
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bookStoreRepository1.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Author> myList()
        {
            var authors = AuthorStoreRepository1.list().ToList();
            authors.Insert(0, new Author { Id = -1, FullName = "---Please choose an author---" });
            return authors;


        }
        public ActionResult Search(string item)
        {
            var result = bookStoreRepository1.Search(item);
            return View("Index",result);
        }
    }
}
