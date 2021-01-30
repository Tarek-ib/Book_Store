using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store1.Models.Repositories
{
    public class BookDbRepository : IBookStoreRepository<Book>
    {
        BookStore1DbContext db;
        public BookDbRepository(BookStore1DbContext _db)
        {
            db = _db;
        }
        public void Add(Book entity)
        {
            //entity.Id = db.BookDbSet.Max(b => b.Id) + 1;
            db.BookDbSet.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = Find(id);
            db.BookDbSet.Remove(book);
            db.SaveChanges();
        }


        public Book Find(int id)
        {
            var book = db.BookDbSet.Include(a => a.Author).SingleOrDefault(b => b.Id == id);
            return book;
        }

        public IList<Book> list()
        {
            return db.BookDbSet.Include(a => a.Author).ToList();
        }

        public void Update(int id, Book entity)
        {
            db.Update(entity);
        }
        public List<Book> Search(string item)
        {
            var result = db.BookDbSet.Include(a => a.Author).Where(b => b.Title.Contains(item)
            || b.Describtion.Contains(item) || b.Author.FullName.Contains(item)).ToList();

            return result;
        }
    }
}


